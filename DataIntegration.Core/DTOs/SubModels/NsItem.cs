using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.DTOs.SubModels
{
    public class NsItem
    {
        public List<NsLink> links { get; set; }
        public string id { get; set; }
    }
}
