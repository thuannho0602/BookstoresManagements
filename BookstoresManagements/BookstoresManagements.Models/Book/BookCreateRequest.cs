using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Models.Book
{
    public class BookCreateRequest
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int? InventoryQuantity { get; set; }
        public int? GenreId { get; set; }
        
        public int? PublisherId { get; set; }
        
        public int? AuthorId { get; set; }
        
    }
}
