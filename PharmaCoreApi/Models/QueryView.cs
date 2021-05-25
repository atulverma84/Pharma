using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class QueryView
    {
        public string DesignDocumentName { get; set; }
        public string ViewName { get; set; }
        public Dictionary<string,string> Filters { get; set; }

    }
}
