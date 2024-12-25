using Newtonsoft.Json;
using System.Text.Json;

namespace ComproPikoulasTest.API.Converters
{
    public class Converter
    {
    }

    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, decimal value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(string.Format("{0:F2}", value));

        }

       
    }
}
