using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBooksMVC.Src.DTOs
{
    public class BookImagesDTO
    {
        [JsonPropertyName("smallThumbnail")]
        public string? SmallThumbnail { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}