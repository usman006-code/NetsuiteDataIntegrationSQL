using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.ViewModel
{
    public class AppSettingViewModel
    {
        //NetSuite Credentials
        public string AccountId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string TokenKey { get; set; }
        public string TokenSecret { get; set; }

        //Email Credentials
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }

        //Database Connection Strings
        public string ConnectionString1 { get; set; }
        public string ConnectionString2 { get; set; }
        public string ConnectionString3 { get; set; }
    }
}
