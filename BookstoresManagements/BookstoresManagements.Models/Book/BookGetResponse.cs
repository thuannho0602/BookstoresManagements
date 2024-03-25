using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Models.Book
{
    public class BookGetResponse
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int? InventoryQuantity { get; set; }
        public int? GenreId { get; set; }
        public string GenreName { get; set; }
        public int? PublisherId { get; set; }
        public string PublisherName { get; set; }
        public int? AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
