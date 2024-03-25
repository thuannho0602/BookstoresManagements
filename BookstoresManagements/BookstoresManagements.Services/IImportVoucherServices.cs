using BookstoresManagements.Models.ImportVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public interface IImportVoucherServices
    {
        Task<List<ImportVoucherGetResponse>> GetAll();

        Task<ImportVoucherGetResponse>GetById(int id);
        Task<ImportVoucherCreateResponse> CreateImportVoucher(ImportVoucherCreateRequest request);
        Task<ImportVoucherUpdateResponse> UpdateImportVoucher(int id, ImportVoucherUpdateRequest request);
        Task<bool> DeleteImportVoucher(int id);
    }
}
