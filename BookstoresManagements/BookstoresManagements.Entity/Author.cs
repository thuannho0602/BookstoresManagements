using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Entity
{
    [Table("Author")] // Tác giả
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string NameAuthor { get; set; }
        [StringLength(20)]
        public string Contact {  get; set; }

    }
}
