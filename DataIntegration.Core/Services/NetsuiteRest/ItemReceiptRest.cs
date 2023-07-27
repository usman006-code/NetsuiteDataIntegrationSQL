using DataIntegration.Core.DTOs;
using DataIntegration.Core.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services.NetsuiteRest
{
    public class ItemReceiptRest
    {
        private readonly ApiHelper apiHelper;
        private string baseUrl;

        public ItemReceiptRest(string accountId, string consumerKey, string consumerSecret, string tokenId, string tokenSecret)
        {
            baseUrl = "https://" + accountId + ".suitetalk.api.netsuite.com/services/rest/record/v1/";
            apiHelper = new ApiHelper(accountId, consumerKey, consumerSecret, tokenId, tokenSecret, baseUrl);
        }

        public async Task<ItemReceiptDTO> GetCustomer(int itemReceiptId)
        {
            string endpoint = $"itemReceipt/{itemReceiptId}";
            return await apiHelper.GetAsync<ItemReceiptDTO>(endpoint);
        }

        public async Task<ResponseDTO> GetAllCustomer()
        {
            string endpoint = "itemReceipt";
            return await apiHelper.GetAsync<ResponseDTO>(endpoint);
        }

        public async Task<ItemReceiptDTO> PostSalesOrder(SalesOrderDTO requestData)
        {
            string endpoint = "itemReceipt";
            return await apiHelper.PostAsync<ItemReceiptDTO>(endpoint, requestData);
        }

        public async Task<ItemReceiptDTO> UpdateSalesOrders(ItemReceiptDTO requestData)
        {
            string endpoint = "itemReceipt";
            return await apiHelper.PutAsync<ItemReceiptDTO>(endpoint, requestData);
        }

        public async Task<ItemReceiptDTO> DeleteSalesOrders(int itemReceiptId)
        {
            string endpoint = $"itemReceipt/{itemReceiptId}";
            return await apiHelper.DeleteAsync<ItemReceiptDTO>(endpoint);
        }
    }
}
