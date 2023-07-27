using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class VendorReturnAuthorizationRest
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public VendorReturnAuthorizationRest(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://" + accountId + ".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId, consumerKey, consumerSecret, tokenId, tokenSecret, baseUrl);
        }

        public async Task<VendorReturnDTO> GetCustomer(int purchaseOrderId)
        {
            string endpoint = $"purchaseOrder/{purchaseOrderId}";
            return await apiHelper.GetAsync<VendorReturnDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetAllCustomer()
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }

        public async Task<VendorReturnDTO> PostSalesOrder(VendorReturnDTO requestData)
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.PostAsync<VendorReturnDTO>(endpoint, requestData);
        }

        public async Task<VendorReturnDTO> UpdateSalesOrders(VendorReturnDTO requestData)
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.PutAsync<VendorReturnDTO>(endpoint, requestData);
        }

        public async Task<VendorReturnDTO> DeleteSalesOrders(int purchaseOrderId)
        {
            string endpoint = $"purchaseOrder/{purchaseOrderId}";
            return await apiHelper.DeleteAsync<VendorReturnDTO>(endpoint);
        }
    }
}
