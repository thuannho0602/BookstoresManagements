using BookstoresManagements.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public interface IBookServices
    {
        Task<List<BookGetResponse>> GetAll();
        Task<BookGetResponse> GetById(int id);
        Task<BookCreateResponse> CreateBook(BookCreateRequest request);
        Task<BookUpdateResponse> UpdateBook(int id, BookUpdateRequest request);
        Task<bool> DeleteBook(int id);
    }
}
