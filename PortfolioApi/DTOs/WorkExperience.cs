﻿using System;
using System.Text.Json.Serialization;
using PortfolioApi.JsonConverters;

namespace PortfolioApi.DTOs
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly StartDate { get; set; }
        [JsonConverter(typeof(NullableDateOnlyJsonConverter))]
        public DateOnly? EndDate { get; set; }
        public string? Title { get; set; }
        [JsonPropertyName("responsibilities")]
        public IEnumerable<WorkResponsibility> WorkResponsibilities { get; set; } = Enumerable.Empty<WorkResponsibility>();
    }
}

