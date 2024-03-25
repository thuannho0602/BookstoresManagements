using BookstoresManagements.DataAccess;
using BookstoresManagements.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Reponsitory.Implementations
{
    public class ImportVoucherReponsitory:RepositoryBase<ImportVoucher,ApplicationDbContext>, IImportVoucherReponsitory
    {
        public ImportVoucherReponsitory(ApplicationDbContext context) : base(context)
        {

        }
    }
}
