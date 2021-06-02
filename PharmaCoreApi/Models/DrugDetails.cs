using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Models
{
    public class DrugDetails
    {
        public string DrugName { get; set; }

        public DateTime DrugExpiredOn { get; set; }

        public string QuantityNo { get; set; }

        public string PartialNo { get; set; }
        public string Expiration { get; set; }

        public string LotNo { get; set; }


    }
}
