using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PortfolioApi.SystemJsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? str = reader.GetString();

            if (string.IsNullOrWhiteSpace(str))
            {
                return DateOnly.MinValue;
            }

            return DateOnlyJsonConverterCommonLogic.NonNullRead(str);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            DateOnlyJsonConverterCommonLogic.NonNullWrite(writer, value);
        }
    }
}

