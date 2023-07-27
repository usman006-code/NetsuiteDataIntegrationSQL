using DataIntegration.Core.Services.NetsuiteRest;
using System.Configuration;

namespace DataIntegration.UI
{
    public partial class Form1 : Form
    {
        private string accountId;
        private string CKey;
        private string CSecret;
        private string tKey;
        private string tSecret;
        public Form1()
        {
            InitializeComponent();
            this.accountId = ConfigurationSettings.AppSettings["AccountId"];
            this.CKey = ConfigurationSettings.AppSettings["ConsumerKey"];
            this.CSecret = ConfigurationSettings.AppSettings["ConsumerSecret"];
            this.tKey = ConfigurationSettings.AppSettings["TokenKey"];
            this.tSecret = ConfigurationSettings.AppSettings["TokenSecret"];
        }

        private void start_Click(object sender, EventArgs e)
        {

            //SalesOrder salesOrder = new SalesOrder(accountId, CKey, CSecret, tKey, tSecret);
            //var obj = salesOrder.GetAllSalesOrders().Result;

            //CustomerRest customerRest = new CustomerRest(accountId, CKey, CSecret, tKey, tSecret);
            //var obj = customerRest.GetCustomer(1).Result;

            
        }
    }
}