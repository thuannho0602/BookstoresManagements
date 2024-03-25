using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Entity
{
    [Table("Publisher")]// Nhà Xuất Bản
    public class Publisher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string NamePublisher {  get; set; }
        [StringLength(250)]
        public string Address {  get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
