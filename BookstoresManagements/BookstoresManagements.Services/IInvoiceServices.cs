using BookstoresManagements.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public interface IInvoiceServices
    {
        Task<List<InvoiceGetResponse>> GetAll();
        Task<InvoiceGetResponse> GetById(int id);
        Task<InvoiceCreateResponse> CreateInvoice(InvoiceCreateRequest request);
        Task<InvoiceUpdateResponse> UpdateInvoice(int id, InvoiceUpdateRequest request);
        Task<bool> DeleteInvoice(int id);
    }
}
