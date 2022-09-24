using System;
using System.Text.Json;

namespace PortfolioApi
{
    public static class DateOnlyJsonConverterCommonLogic
    {
        public static DateOnly NonNullRead(string str)
        {
            DateTime dateTime = JsonSerializer.Deserialize<DateTime>(str);

            return DateOnly.FromDateTime(dateTime);
        }

        public static void NonNullWrite(Utf8JsonWriter writer, DateOnly value)
        {
            string str = value.ToString("yyyy-MM-dd\"T00:00:00\"");

            writer.WriteStringValue(str);
        }
    }
}

