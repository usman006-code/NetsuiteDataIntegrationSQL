using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class SalesOrderRest
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public SalesOrderRest(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://"+accountId+".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId,consumerKey, consumerSecret, tokenId, tokenSecret,baseUrl);
        }

        public async Task<SalesOrderDTO> GetSalesOrder(int salesOrderId)
        {
            string endpoint = $"salesorder/{salesOrderId}";
            return await apiHelper.GetAsync<SalesOrderDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetAllSalesOrders()
        {
            string endpoint = "salesorder";
             return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }

        public async Task<SalesOrderDTO> PostSalesOrder(SalesOrderDTO requestData)
        {
            string endpoint = "salesorder";
            return await apiHelper.PostAsync<SalesOrderDTO>(endpoint,requestData);
        }

        public async Task<SalesOrderDTO> UpdateSalesOrders(SalesOrderDTO requestData)
        {
            string endpoint = "salesorder";
            return await apiHelper.PutAsync<SalesOrderDTO>(endpoint,requestData);
        }

        public async Task<SalesOrderDTO> DeleteSalesOrders(int salesOrderId)
        {
            string endpoint = $"salesorder/{salesOrderId}";
            return await apiHelper.DeleteAsync<SalesOrderDTO>(endpoint);
        }
    }
}
