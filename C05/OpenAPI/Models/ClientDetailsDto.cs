﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAPI.Models
{
    public class ClientDetailsDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contracts")]
        public IEnumerable<ContractDetailsDto> Contracts { get; set; }
    }
}
