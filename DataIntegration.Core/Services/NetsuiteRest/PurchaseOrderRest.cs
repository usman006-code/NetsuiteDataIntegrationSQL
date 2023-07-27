using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class PurchaseOrderRest
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public PurchaseOrderRest(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://" + accountId + ".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId, consumerKey, consumerSecret, tokenId, tokenSecret, baseUrl);
        }

        public async Task<PurchaseOrderDTO> GetCustomer(int purchaseOrderId)
        {
            string endpoint = $"purchaseOrder/{purchaseOrderId}";
            return await apiHelper.GetAsync<PurchaseOrderDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetAllCustomer()
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }

        public async Task<PurchaseOrderDTO> PostSalesOrder(PurchaseOrderDTO requestData)
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.PostAsync<PurchaseOrderDTO>(endpoint, requestData);
        }

        public async Task<PurchaseOrderDTO> UpdateSalesOrders(PurchaseOrderDTO requestData)
        {
            string endpoint = "purchaseOrder";
            return await apiHelper.PutAsync<PurchaseOrderDTO>(endpoint, requestData);
        }

        public async Task<PurchaseOrderDTO> DeleteSalesOrders(int purchaseOrderId)
        {
            string endpoint = $"purchaseOrder/{purchaseOrderId}";
            return await apiHelper.DeleteAsync<PurchaseOrderDTO>(endpoint);
        }
    }
}
