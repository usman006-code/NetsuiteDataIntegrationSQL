using DataIntegration.Core.DTOs.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.DTOs
{
    public class ResponseDTO
    {
        public List<NsLink> links { get; set; }
        public int count { get; set; }
        public bool hasMore { get; set; }
        public List<NsItem> items { get; set; }
        public int offset { get; set; }
        public int totalResults { get; set; }
    }


}
