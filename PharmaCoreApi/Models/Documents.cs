using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class Documents
    {
        public Document[] documents;
    }

    public class Document
    {
        public Dictionary<string, string> document;
    }
}
