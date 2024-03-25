using BookstoresManagements.Models.ImportVoucher;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportVouchersController : BaseController
    {
        private readonly IImportVoucherServices _importVoucherServices;
        public ImportVouchersController(IImportVoucherServices importVoucherServices)
        {
            _importVoucherServices = importVoucherServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ImportVoucherGetResponse>> GetAll()
        {
            return await _importVoucherServices.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<ImportVoucherGetResponse>GetById(int Id)
        {
            return await _importVoucherServices.GetById(Id);
        }

        [HttpPost]
        public async Task<ImportVoucherCreateResponse> Create(ImportVoucherCreateRequest request)
        {
            return await _importVoucherServices.CreateImportVoucher(request);
        }

        [HttpPut("{Id}")]
        public async Task<ImportVoucherUpdateResponse> Update(int Id, ImportVoucherUpdateRequest request)
        {
            return await _importVoucherServices.UpdateImportVoucher(Id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int Id)
        {
            return await _importVoucherServices.DeleteImportVoucher(Id);
        }
    }
}
