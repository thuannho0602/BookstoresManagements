using BookstoresManagements.Entity;
using BookstoresManagements.Models.ImportVoucher;
using BookstoresManagements.Reponsitory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class ImportVoucherServices : IImportVoucherServices
    {
        private readonly IImportVoucherReponsitory _importVoucherReponsitory;
        public ImportVoucherServices(IImportVoucherReponsitory importVoucherReponsitory) 
        {
            _importVoucherReponsitory = importVoucherReponsitory;
        }
        public async Task<ImportVoucherCreateResponse> CreateImportVoucher(ImportVoucherCreateRequest request)
        {
            if(request.Id == 0)
            {
                var importVocher = new ImportVoucher
                {
                    ImportDate = DateTime.Now,
                    PublisherId = request.PublisherId,
                };
                _importVoucherReponsitory.Add(importVocher);
                _importVoucherReponsitory.SaveChanges();

                var date = _importVoucherReponsitory.FindAll()
                    .Include(c => c.Publisher)
                    .Where(c => c.Id == importVocher.Id).FirstOrDefault();

                var importVocherResponse = new ImportVoucherCreateResponse
                {
                    Id = importVocher.Id,
                    ImportDate = DateTime.Now,
                    PublisherId = importVocher.PublisherId,
                    PublisherName = date.Publisher.NamePublisher
                };
                return await Task.FromResult(importVocherResponse);
            }
            return new ImportVoucherCreateResponse();
        }

        public async Task<bool> DeleteImportVoucher(int id)
        {
           var importVoucher=_importVoucherReponsitory.FindByCondition(c=>c.Id == id).FirstOrDefault();
            if(importVoucher != null)
            {
                _importVoucherReponsitory.Remove(importVoucher);
                _importVoucherReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        public async Task<List<ImportVoucherGetResponse>> GetAll()
        {
            var listImportVoucher=_importVoucherReponsitory.FindAll().Select(c=>new ImportVoucherGetResponse
            {
                Id=c.Id,
                ImportDate=DateTime.Now,
                PublisherId=c.PublisherId,
                PublisherName=c.Publisher.NamePublisher,
            }).ToList();
            return await Task.FromResult(listImportVoucher);
        }

        public async Task<ImportVoucherGetResponse> GetById(int id)
        {
            var importVoucherId=_importVoucherReponsitory.FindByCondition(x=>x.Id==id).Select(c=>new ImportVoucherGetResponse
            {
                Id = c.Id,
                ImportDate = DateTime.Now,
                PublisherId = c.PublisherId,
                PublisherName = c.Publisher.NamePublisher,
            }).FirstOrDefault();
            return await Task.FromResult(importVoucherId);
        }

        public async Task<ImportVoucherUpdateResponse> UpdateImportVoucher(int id, ImportVoucherUpdateRequest request)
        {
            if (id > 0)
            {
                var importVoucherId = _importVoucherReponsitory.FindByCondition(x => x.Id == id).FirstOrDefault();
                if(importVoucherId != null)
                {
                    var importVoucher = new ImportVoucher
                    {
                        Id = id,
                        ImportDate = DateTime.Now,
                        PublisherId = request.PublisherId,
                    };
                    _importVoucherReponsitory.Update(importVoucher);
                    _importVoucherReponsitory.SaveChanges();
                    var data = _importVoucherReponsitory.FindAll()
                        .Include(x => x.Publisher)
                        .Where(x => x.Id == importVoucher.Id).FirstOrDefault();
                    var importVoucherResponse = new ImportVoucherUpdateResponse
                    {
                        Id = id,
                        ImportDate = DateTime.Now,
                        PublisherId = importVoucher.PublisherId,
                        PublisherName = data.Publisher.NamePublisher,
                    };
                    return await Task.FromResult(importVoucherResponse);
                }
                return new ImportVoucherUpdateResponse();
            }
            return new ImportVoucherUpdateResponse();
        }
    }
}
