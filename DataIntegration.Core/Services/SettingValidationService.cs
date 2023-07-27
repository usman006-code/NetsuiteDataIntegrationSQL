using DataIntegration.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services
{
    public static class SettingValidationService
    {
        public static ServiceResponse ValidateAppSettings(AppSettingViewModel appSetting)
        {
            ServiceResponse serviceResponse = new ServiceResponse()
            {
                IsSuccess = true,
                Message = ""
            };
            if (appSetting == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "App Setting is Empty";
                return serviceResponse;
            }
                
            string validationMessage = string.Empty;

            //Netsuite Credentials
            if (string.IsNullOrEmpty(appSetting.AccountId.Trim()))
                validationMessage += "Netsuite Account ID is required\n";
            if (string.IsNullOrEmpty(appSetting.ConsumerKey.Trim()))
                validationMessage += "Netsuite Consumer Key is required\n";
            if(string.IsNullOrEmpty(appSetting.ConsumerSecret.Trim()))
                validationMessage += "Netsuite Consumer Secret is required\n";
            if (string.IsNullOrEmpty(appSetting.TokenKey.Trim()))
                validationMessage += "Netsuite Token Key is required\n";
            if (string.IsNullOrEmpty(appSetting.TokenSecret.Trim()))
                validationMessage += "Netsuite Token Secret is required\n";

            //Email Credentials 
            if (string.IsNullOrEmpty(appSetting.SenderEmail.Trim()))
                validationMessage += "Netsuite Sender Email is required\n";
            if (string.IsNullOrEmpty(appSetting.SenderPassword.Trim()))
                validationMessage += "Netsuite Sender Password is required\n";
            if (string.IsNullOrEmpty(appSetting.SmtpHost.Trim()))
                validationMessage += "Netsuite Smtp Host is required\n";
            if (string.IsNullOrEmpty(appSetting.SmtpPort.Trim()))
                validationMessage += "Netsuite Smtp Port is required\n";

            //Connection Strings
            if (string.IsNullOrEmpty(appSetting.ConnectionString1.Trim()))
                validationMessage += "MS SQL Connection String (1) is required\n";
            if (string.IsNullOrEmpty(appSetting.ConnectionString2.Trim()))
                validationMessage += "MS SQL Connection String (2) is required\n";
            if (string.IsNullOrEmpty(appSetting.ConnectionString3.Trim()))
                validationMessage += "MS SQL Connection String (3) is required\n";

            if (!string.IsNullOrEmpty(validationMessage)) 
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = validationMessage;
            }

            return serviceResponse;
        }
    }
}
