using BookstoresManagements.DataAccess;
using BookstoresManagements.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Reponsitory.Implementations
{
    public class PublisherReponsitory:RepositoryBase<Publisher,ApplicationDbContext>, IPublisherReponsitory
    {
        public PublisherReponsitory(ApplicationDbContext context) : base(context)
        {

        }
    }
}
