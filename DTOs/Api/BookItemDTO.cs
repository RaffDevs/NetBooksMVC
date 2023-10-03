using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBooksMVC.Src.DTOs
{
    public class BookItemDTO
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("selfLink")]
        public string? SelfLink { get; set; }

        [JsonPropertyName("volumeInfo")]
        public BookInfoDTO? VolumeInfo { get; set; }
    }
}