using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class ListPharmaDetails
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("_rev")]
        public string Rev { get; set; }

        [JsonProperty("PharmaDetails")]
        public List<PharmaDetails> PharmaDetails { get; set; }
    }
}
