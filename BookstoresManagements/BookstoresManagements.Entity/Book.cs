using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Entity
{
    [Table("Book")] // Sách
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string NameBook {  get; set; }
        public int? InventoryQuantity { get; set; }
        public int? GenreId {  get; set; }
        public Genre Genre {  get; set; }
        public int? PublisherId {  get; set; }
        public Publisher Publisher { get; set; }
        public int? AuthorId {  get; set; }
        public Author Author { get; set; }
    }
}
