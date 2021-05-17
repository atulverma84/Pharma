using System;
using System.Text.Json.Serialization;

namespace PharmaCoreApi.Models
{
    public class UpdatePharmaDetails
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string Rev { get; set; }

        public string Name { get; set; }

        public DateTime ExpiredOn { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}