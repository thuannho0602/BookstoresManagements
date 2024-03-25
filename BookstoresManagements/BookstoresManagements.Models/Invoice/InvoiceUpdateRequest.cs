using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Models.Invoice
{
    public class InvoiceUpdateRequest
    {
        public int id { get; set; }
        public DateTime? SalesDate { get; set; }
    }
}
