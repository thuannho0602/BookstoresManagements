using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoresManagements.Entity
{
    [Table("Genre")] // Loại
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string NameGenre {  get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
