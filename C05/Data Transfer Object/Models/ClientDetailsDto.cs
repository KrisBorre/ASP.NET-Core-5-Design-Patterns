﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models
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
