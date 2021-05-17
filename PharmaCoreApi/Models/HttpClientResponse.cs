using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class HttpClientResponse
    {
        public bool IsSuccess { get; set; }
        public dynamic SuccessContentObject { get; set; }
        public string FailedReason { get; set; }

        public dynamic Result { get; set; }

    }
}
