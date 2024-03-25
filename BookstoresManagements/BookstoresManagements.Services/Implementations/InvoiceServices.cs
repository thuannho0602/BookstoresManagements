using BookstoresManagements.Entity;
using BookstoresManagements.Models.Invoice;
using BookstoresManagements.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IInvoiceReponsitory _invoiceReponsitory;
        public InvoiceServices(IInvoiceReponsitory invoiceReponsitory)
        {
            _invoiceReponsitory = invoiceReponsitory;
        }

        public async Task<InvoiceCreateResponse> CreateInvoice(InvoiceCreateRequest request)
        {
            if(request.id == 0)
            {
                var invoice = new Invoice
                {
                    SalesDate = request.SalesDate,
                };
                _invoiceReponsitory.Add(invoice);
                _invoiceReponsitory.SaveChanges();

                var invoiceResponse = new InvoiceCreateResponse
                {
                    id = invoice.id,
                    SalesDate = invoice.SalesDate,
                };
                return await Task.FromResult(invoiceResponse);
            }
            return new InvoiceCreateResponse();
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            var invoiceId=_invoiceReponsitory.FindByCondition(c=>c.id== id).FirstOrDefault();
            if(invoiceId != null)
            {
                _invoiceReponsitory.Remove(invoiceId);
                _invoiceReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        public async Task<List<InvoiceGetResponse>> GetAll()
        {
            var listInvoice = _invoiceReponsitory.FindAll().Select(c => new InvoiceGetResponse
            {
                id = c.id,
                SalesDate = c.SalesDate,
            }).ToList();
            return await Task.FromResult(listInvoice);
        }

        public async Task<InvoiceGetResponse> GetById(int id)
        {
            var invoiceId=_invoiceReponsitory.FindByCondition(x=>x.id== id).Select(c=>new InvoiceGetResponse
            {
                id=c.id,
                SalesDate = c.SalesDate,
            }).FirstOrDefault();
            return await Task.FromResult(invoiceId);
        }

        public async Task<InvoiceUpdateResponse> UpdateInvoice(int id, InvoiceUpdateRequest request)
        {
            if (id > 0)
            {
                var invoiceId = _invoiceReponsitory.FindByCondition(c => c.id == id).FirstOrDefault();
                if(invoiceId != null)
                {
                    var invoice = new Invoice
                    {
                        id=id,
                        SalesDate = request.SalesDate,
                    };
                    _invoiceReponsitory.Update(invoice);
                    _invoiceReponsitory.SaveChanges();

                    var invoiceResponse = new InvoiceUpdateResponse
                    {
                        id = id,
                        SalesDate = invoice.SalesDate,
                    };
                    return await Task.FromResult(invoiceResponse);
                }
                return new InvoiceUpdateResponse();
            }
            return new InvoiceUpdateResponse();
        }
    }
}
