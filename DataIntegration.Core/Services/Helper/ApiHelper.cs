using DataIntegration.Core.DTOs.SubModels;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.Helper
{
    public class ApiHelper
    {
        private string _accountId;
        private string _consumerKey;
        private string _consumerSecret;
        private string _tokenId;
        private string _tokenSecret;
        private string _oAuthVersion;
        private string _baseUrl;
        private string _oAuthSignatureMethod;

        public ApiHelper(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret, string baseUrl, string oAuthSignatureMethod = "HMAC-SHA256")
        {
            this._accountId = accountId;
            this._consumerKey = consumerKey;
            this._consumerSecret = consumerSecret;
            this._tokenId = tokenId;
            this._tokenSecret = tokenSecret;
            this._oAuthVersion = "1.0";
            this._oAuthSignatureMethod = oAuthSignatureMethod;
            this._baseUrl = baseUrl;
        }
        //Start - API Calls
        public async Task<T> GetAsync<T>(string requestUri)
        {
            Method method = Method.Get;
            return await SendRestRequestAsync<T>(method, requestUri);
        }
        public async Task<T> PostAsync<T>(string requestUri, object data)
        {
            Method method = Method.Post;
            return await SendRestRequestAsync<T>(method, requestUri,data);
        }
        public async Task<T> PutAsync<T>(string requestUri, object data)
        {
            Method method = Method.Patch;
            return await SendRestRequestAsync<T>(method, requestUri,data);
        }
        public async Task<T> DeleteAsync<T>(string requestUri)
        {
            Method method = Method.Delete;
            return await SendRestRequestAsync<T>(method,requestUri);
        }
        //End - API Calls



        //Start - API Helper functions - RestSharp
        public async Task<T> SendRestRequestAsync<T>(Method method, string requestUri,object requestData=null ,string contentType = "application/json")
        {
            try
            {
                string URL = _baseUrl + requestUri;
                var client = new RestClient(URL);
                var oAuth1 = OAuth1Authenticator.ForAccessToken(
                                consumerKey: _consumerKey,
                                consumerSecret: _consumerSecret,
                                token: _tokenId,
                                tokenSecret: _tokenSecret,
                                OAuthSignatureMethod.HmacSha256);
                oAuth1.Realm = _accountId.ToUpper().Replace('-', '_');
                client.Authenticator = oAuth1;

                var request = new RestRequest(URL, method);
                request.AddHeader("Content-Type", contentType);

                if (requestData != null)
                {
                    request.AddJsonBody(requestData);
                    //request.AddParameter("application/json", requestData, ParameterType.RequestBody);
                }
                var response = client.ExecuteAsync(request).GetAwaiter().GetResult();
                if(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content);
                }
                else
                {
                    var errorResponse = JsonConvert.DeserializeObject<NsError>(response.Content);
                    string errorDetail = "";
                    foreach (var error in errorResponse.oerrorDetails)
                    {
                        if (errorResponse.oerrorDetails.Count == 1)
                        {
                            errorDetail += error.detail;
                        }
                        errorDetail += error.detail + " and ";
                    }
                    
                    throw new ApiException($"API Error: {errorDetail}", null, response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Handle specific exceptions or log the error
                throw new Exception("Error during API request.", ex);
            }
            
        }
        //End - API Helper functions - RestSharp



        //Start - API Helper functions - Through WebRequest
        private HttpWebRequest CreateWebRequest(string requestUri, string method, string contentType = "application/json")
        {
            // Set up the OAuth parameters
            string url = _baseUrl + requestUri;
            string oauthNonce = GenerateNonce();
            string oauthTimestamp = GenerateTimestamp();
            string oauthSignatureMethod = _oAuthSignatureMethod;
            string oauthSignature = GenerateSignature(oauthNonce, oauthTimestamp, oauthSignatureMethod, url,method);

            var request = (HttpWebRequest)WebRequest.Create(new Uri(new Uri(_baseUrl), requestUri));
            request.Method = method;
            request.Headers["Authorization"] = GenerateAuthorizationHeader(oauthNonce, oauthTimestamp, oauthSignatureMethod, oauthSignature);
            request.ContentType = contentType;
            return request;
        }
        private async Task<T> SendWebRequestAsync<T>(HttpWebRequest request, string requestData = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(requestData))
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(requestData);
                        streamWriter.Flush();
                    }
                }

                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                using (var responseStream = response.GetResponseStream())
                using (var streamReader = new StreamReader(responseStream))
                {
                    var responseJson = await streamReader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(responseJson);
                }
            }
            catch (WebException ex)
            {
                // Handle specific exceptions or log the error
                throw new Exception("Error during API request.", ex);
            }
        }
        private string GenerateNonce()
        {
            return Guid.NewGuid().ToString("N");
        }
        private string GenerateTimestamp()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToInt64(t.TotalSeconds).ToString();
        }
        private string GenerateSignature(string oauthNonce, string oauthTimestamp, string oauthSignatureMethod, string url,string method)
        {
            //string url = $"https://{_accountId}.suitetalk.api.netsuite.com/services/rest/record/v1/customer/1";
            string signatureBase = $"{method}&{Uri.EscapeDataString(url)}&oauth_consumer_key={_consumerKey}&oauth_nonce={oauthNonce}&oauth_signature_method={oauthSignatureMethod}&oauth_timestamp={oauthTimestamp}&oauth_token={_tokenId}&oauth_version={_oAuthVersion}";
            string signingKey = $"{Uri.EscapeDataString(_consumerSecret)}&{Uri.EscapeDataString(_tokenSecret)}";
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(signingKey)))
            {
                byte[] signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signatureBase));
                string signature = Convert.ToBase64String(signatureBytes);
                return Uri.EscapeDataString(signature);
            }
        }
        private string GenerateAuthorizationHeader(string oauthNonce, string oauthTimestamp, string oauthSignatureMethod, string oauthSignature)
        {
            string authorizationHeader = $"OAuth oauth_consumer_key=\"{_consumerKey}\", oauth_nonce=\"{oauthNonce}\", oauth_signature=\"{oauthSignature}\", oauth_signature_method=\"{oauthSignatureMethod}\", oauth_timestamp=\"{oauthTimestamp}\", oauth_token=\"{_tokenId}\", oauth_version=\"{_oAuthVersion}\"";
            return authorizationHeader;
        }
        //End - API Helper functions - Through WebRequest
    }
}
