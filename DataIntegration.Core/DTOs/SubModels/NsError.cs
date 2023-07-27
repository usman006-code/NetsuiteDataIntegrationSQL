using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Core.DTOs.SubModels
{
    public class OErrorDetail
    {
        public string detail { get; set; }

        [JsonProperty("o:errorCode")]
        public string oerrorCode { get; set; }

        [JsonProperty("o:errorHeader")]
        public string oerrorHeader { get; set; }

        [JsonProperty("o:errorPath")]
        public string oerrorPath { get; set; }

        [JsonProperty("o:errorQueryParam")]
        public string oerrorQueryParam { get; set; }

        [JsonProperty("o:errorUrl")]
        public string oerrorUrl { get; set; }

    }

    public class NsError
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }

        [JsonProperty("o:errorDetails")]
        public List<OErrorDetail> oerrorDetails { get; set; }
    }
}
