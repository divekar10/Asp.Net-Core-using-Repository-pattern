using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [DisplayName("Book Name")]
        public string BookName { get; set; }

        public int AuthorId { get; set; }
    }
}
