using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBooksMVC.Src.DTOs
{
    public class BookInfoDTO
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("authors")]
        public List<string>? Authors { get; set; }

        [JsonPropertyName("publisher")]
        public string? Publisher { get; set; }

        [JsonPropertyName("publishedDate")]
        public string? PublishedDate { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("pageCount")]
        public int? PageCount { get; set; }

        [JsonPropertyName("categories")]
        public List<string>? Categories { get; set; }

        [JsonPropertyName("imageLinks")]
        public BookImagesDTO? ImageLinks { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }
    }
}