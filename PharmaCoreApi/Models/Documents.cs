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
        public string value { get; set; }
    }
}
