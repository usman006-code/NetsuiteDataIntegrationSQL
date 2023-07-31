using DataIntegration.Core.ViewModel;
using DataIntegration.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.Services
{
    public class TestService
    {
        private TestRepo testRepo;
        public TestService(AppSettingViewModel setting)
        {
            testRepo = new TestRepo(setting.ConnectionString1);
        }
        public string test()
        {
            testRepo.TestAsyncData();
            return "";
        }
    }
}
