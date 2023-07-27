using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class SalesOrder
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public SalesOrder(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://"+accountId+".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId,consumerKey, consumerSecret, tokenId, tokenSecret,baseUrl);
        }

        public async Task<SalesOrderDTO> GetSalesOrder(int salesOrderId)
        {
            string endpoint = $"salesorder/{salesOrderId}";
            return await apiHelper.GetAsync<SalesOrderDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetSalesOrder()
        {
            string endpoint = "salesorder";
            return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }
    }
}
