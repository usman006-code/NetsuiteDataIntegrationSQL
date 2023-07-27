using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class CustomerRest
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public CustomerRest(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://" + accountId + ".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId, consumerKey, consumerSecret, tokenId, tokenSecret, baseUrl);
        }

        public async Task<CustomerDTO> GetCustomer(int customerId)
        {
            string endpoint = $"customer/{customerId}";
            return await apiHelper.GetAsync<CustomerDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetAllCustomer()
        {
            string endpoint = "customer";
            return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }

        public async Task<CustomerDTO> PostSalesOrder(SalesOrderDTO requestData)
        {
            string endpoint = "customer";
            return await apiHelper.PostAsync<CustomerDTO>(endpoint, requestData);
        }

        public async Task<CustomerDTO> UpdateSalesOrders(CustomerDTO requestData)
        {
            string endpoint = "customer";
            return await apiHelper.PutAsync<CustomerDTO>(endpoint, requestData);
        }

        public async Task<CustomerDTO> DeleteSalesOrders(int customerId)
        {
            string endpoint = $"customer/{customerId}";
            return await apiHelper.DeleteAsync<CustomerDTO>(endpoint);
        }
    }
}
