using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetBooksMVC.Models
{
    [Table("BookCollection")]
    public class BookCollection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("OwnerUserId")]
        public string OwnerUserId { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}