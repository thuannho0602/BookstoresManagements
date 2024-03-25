using BookstoresManagements.DataAccess;
using BookstoresManagements.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Reponsitory.Implementations
{
    public class AuthorReponsitory:RepositoryBase<Author,ApplicationDbContext>, IAuthorReponsitory
    {
        public AuthorReponsitory(ApplicationDbContext context):base(context)
        { 
        }
    }
}
