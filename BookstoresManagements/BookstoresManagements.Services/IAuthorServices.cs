using BookstoresManagements.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public interface IAuthorServices
    {
        Task<List<AuthorGetResponse>> GetAllAuthor();
        Task<AuthorGetResponse> GetByIdAuthor(int id);
        Task<AuthorCreateResponse> CreateAuthor(AuthorCreateRequest request);
        Task<AuthorUpdateResponse> UpdateAuthor(int id, AuthorUpdateRequest authorUpdateRequest);
        Task<bool> DeleteAuthor(int id);
    }
}
