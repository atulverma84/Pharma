using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace PharmaCoreApi.Helper
{
    public class TrimmingConverter : JsonConverter
    {
              
        private static readonly Regex SpaceRemover = new Regex(@"\s+", RegexOptions.Compiled);

        public override bool CanConvert(Type objectType) => objectType == typeof(string);

        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {           
           if (reader.Value.GetType() == typeof(Int64) &&  Convert.ToInt64(reader.Value) > 0)
                    return Convert.ToString(reader.Value);

          return  TrimInputField((string)reader.Value);
        }
           

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            => throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");

        public string TrimInputField(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            input = input.Trim();
            input = SpaceRemover.Replace(input, " ");

            return input;
        }
    }
}

