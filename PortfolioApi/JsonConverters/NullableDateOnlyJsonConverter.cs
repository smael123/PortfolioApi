using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PortfolioApi.JsonConverters
{
    public class NullableDateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? str = reader.GetString();

            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            DateTime dateTime = JsonSerializer.Deserialize<DateTime>(str);

            return DateOnly.FromDateTime(dateTime);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            string? str = null;

            if (value.HasValue)
            {
                str = value.Value.ToString("yyyy-MM-dd\"T00:00:00\"");
            }

            writer.WriteStringValue(str);
        }
    }
}

