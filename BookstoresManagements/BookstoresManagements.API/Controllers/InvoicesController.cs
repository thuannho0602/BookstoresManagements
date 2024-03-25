using BookstoresManagements.Models.Invoice;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : BaseController
    {
        private readonly IInvoiceServices _invoiceServices;
        public InvoicesController(IInvoiceServices invoiceServices)
        {
            _invoiceServices = invoiceServices;
        }
        [HttpGet]
        public async Task<IEnumerable<InvoiceGetResponse>> GetAll() 
        {
            return await _invoiceServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<InvoiceGetResponse> GetById(int id)
        {
            return await _invoiceServices.GetById(id);
        }

        [HttpPost]
        public async Task<InvoiceCreateResponse> Create(InvoiceCreateRequest request)
        {
            return await _invoiceServices.CreateInvoice(request);
        }

        [HttpPut("{Id}")]
        public async Task<InvoiceUpdateResponse> Update(int id,InvoiceUpdateRequest request)
        {
            return await _invoiceServices.UpdateInvoice(id,request);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int id)
        {
            return await _invoiceServices.DeleteInvoice(id);
        }
    }
}
