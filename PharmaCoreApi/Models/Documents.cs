using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class Documents
    {
        public string total_rows { get; set; }
        public string offset { get; set; }

        public List<rows> rows { get; set; }
    }

    public class rows
    {
        public string id { get; set; }
        public string key { get; set; }
        public value value { get; set; }
    }

    public class value
    {
        public string _id { get; set; }
        public string DNdcNbr { get; set; }
        public string DManName { get; set; }
        public string DFormCode { get; set; }
        public string DStrength { get; set; }
        public string DProductName { get; set; }
        public string DPackSize { get; set; }

        
    }
}
