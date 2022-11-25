using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarPark.DAL.Commons
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string format = "HH:mm:ss";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeOnly.ParseExact(reader.GetString()!, format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(format, CultureInfo.InvariantCulture));
        }
    }
}