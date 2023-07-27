using DataIntegration.Core.Services;
using DataIntegration.Core.Services.NetsuiteRest;
using DataIntegration.Core.ViewModel;
using System.Configuration;

namespace DataIntegration.UI
{
    public partial class Form1 : Form
    {
        private AppSettingViewModel appSettings;
        public Form1()
        {
            InitializeComponent();
            appSettings = new AppSettingViewModel();
            //Netsuite Credentials
            appSettings.AccountId = ConfigurationSettings.AppSettings["AccountId"];
            appSettings.ConsumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
            appSettings.ConsumerSecret = ConfigurationSettings.AppSettings["ConsumerSecret"];
            appSettings.TokenKey = ConfigurationSettings.AppSettings["TokenKey"];
            appSettings.TokenSecret = ConfigurationSettings.AppSettings["TokenSecret"];

            //Email Credentials
            appSettings.SenderEmail = ConfigurationSettings.AppSettings["SenderEmail"];
            appSettings.SenderPassword = ConfigurationSettings.AppSettings["SenderPassword"];
            appSettings.SmtpHost = ConfigurationSettings.AppSettings["SmtpHost"];
            appSettings.SmtpPort = ConfigurationSettings.AppSettings["SmtpPort"];

            //Database connection strings
            appSettings.ConnectionString1 = ConfigurationSettings.AppSettings["ConnectionString1"];
            appSettings.ConnectionString2 = ConfigurationSettings.AppSettings["ConnectionString2"];
            appSettings.ConnectionString3 = ConfigurationSettings.AppSettings["ConnectionString3"];

        }

        private void start_Click(object sender, EventArgs e)
        {
            var serviceResponse = SettingValidationService.ValidateAppSettings(appSettings);

            //SalesOrder salesOrder = new SalesOrder(accountId, CKey, CSecret, tKey, tSecret);
            //var obj = salesOrder.GetAllSalesOrders().Result;

            //CustomerRest customerRest = new CustomerRest(accountId, CKey, CSecret, tKey, tSecret);
            //var obj = customerRest.GetCustomer(1).Result;
            richTextBox1.Text = serviceResponse.Message;
        }
    }
}