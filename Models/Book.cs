using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetBooksMVC.Models;

namespace NetBooksMVC.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Authors { get; set; }

        [DefaultValue("Unknow")]
        public string? Publisher { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int? PageCount { get; set; }

        public string? Language { get; set; }

        public string? ThumbnailLinkSmall { get; set; }

        public string? ThumbnailLink { get; set; }

        [Required]
        public string BookId { get; set; }
    }
}