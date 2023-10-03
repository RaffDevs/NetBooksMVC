using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetBooksMVC.Src.DTOs
{
    public class GoogleBookDTO
    {
        [JsonPropertyName("totalItems")]
        public int? TotalItems { get; set; }

        [JsonPropertyName("items")]
        public List<BookItemDTO>? Books { get; set; }
    }
}