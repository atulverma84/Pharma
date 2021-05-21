using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class Query
    {
        public Dictionary<string,string> selector { get; set; }

        public string[] fields { get; set; }
    }
}
