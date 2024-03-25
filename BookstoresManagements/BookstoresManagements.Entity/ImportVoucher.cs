using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Entity
{
    [Table("ImportVoucher")] // Phiếu Nhập
    public class ImportVoucher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ImportDate {  get; set; }
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
