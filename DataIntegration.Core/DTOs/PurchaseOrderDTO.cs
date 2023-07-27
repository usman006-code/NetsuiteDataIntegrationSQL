using DataIntegration.Core.DTOs.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.DTOs
{
    public class PurchaseOrderDTO
    {
        public string Id { get; set; }
        public List<NsLink> link { get; set; }
    }
}
