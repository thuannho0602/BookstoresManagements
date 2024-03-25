using BookstoresManagements.Entity;
using BookstoresManagements.Models.Authors;
using BookstoresManagements.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorReponsitory _authorReponsitory;
        public AuthorServices(IAuthorReponsitory authorReponsitory)
        {
            _authorReponsitory = authorReponsitory;
        }

        public async Task<AuthorCreateResponse> CreateAuthor(AuthorCreateRequest request)
        {
            if (request.Id == 0)
            {
                var author = new Author
                {
                    NameAuthor = request.NameAuthor,
                    Contact = request.Contact,
                };

                _authorReponsitory.Add(author);
                _authorReponsitory.SaveChanges();

                var authorResponse = new AuthorCreateResponse
                {
                    Id = author.Id,
                    NameAuthor = author.NameAuthor,
                    Contact = author.Contact,
                };
                return await Task.FromResult(authorResponse);
            }
            return new AuthorCreateResponse();
        }

        public async Task<bool> DeleteAuthor(int id)
        {
           var deleteAuthor=_authorReponsitory.FindByCondition(x=>x.Id == id).FirstOrDefault();
            if(deleteAuthor != null)
            {
                _authorReponsitory.Remove(deleteAuthor);
                _authorReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        public async Task<List<AuthorGetResponse>> GetAllAuthor()
        {
           var listAuthor=_authorReponsitory.FindAll().Select(c=>new AuthorGetResponse
           {
               Id=c.Id,
               NameAuthor = c.NameAuthor,
               Contact = c.Contact,
           }).ToList();
            return await Task.FromResult(listAuthor);
        }

        public async Task<AuthorGetResponse> GetByIdAuthor(int id)
        {
            var authorId=_authorReponsitory.FindByCondition(x=>x.Id==id).Select(c=>new AuthorGetResponse
            {
                Id = c.Id,
                NameAuthor = c.NameAuthor,
                Contact = c.Contact,
            }).FirstOrDefault();
            return await Task.FromResult(authorId);
        }

        public async Task<AuthorUpdateResponse> UpdateAuthor(int id, AuthorUpdateRequest authorUpdateRequest)
        {
           if(id>0)
           {
                var authorId=_authorReponsitory.FindByCondition(x=>x.Id==id).FirstOrDefault();
                if (authorId != null)
                {
                    var author = new Author
                    {
                        Id = id,
                        NameAuthor = authorUpdateRequest.NameAuthor,
                        Contact = authorUpdateRequest.Contact,
                    };
                    _authorReponsitory.Update(author);
                    _authorReponsitory.SaveChanges();

                    var authorResponse = new AuthorUpdateResponse
                    {
                        Id = id,
                        NameAuthor = author.NameAuthor,
                        Contact = author.Contact,
                    };
                    return await Task.FromResult(authorResponse);
                }
                return new AuthorUpdateResponse();
           }
            return new AuthorUpdateResponse();
        }
    }
}
