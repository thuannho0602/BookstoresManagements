using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Models.Authors
{
    public class AuthorCreateRequest
    {
        public int Id { get; set; }
       
        public string NameAuthor { get; set; }
       
        public string Contact { get; set; }
    }
}
