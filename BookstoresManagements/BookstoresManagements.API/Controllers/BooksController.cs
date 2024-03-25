using BookstoresManagements.Models.Book;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [HttpGet]
        public async Task<IEnumerable<BookGetResponse>> GetAll()
        {
            return await _bookServices.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<BookGetResponse> GetById(int id)
        {
            return await _bookServices.GetById(id);
        }

        [HttpPost]
        public async Task<BookCreateResponse> CreateResponse(BookCreateRequest request)
        {
            return await _bookServices.CreateBook(request);
        }

        [HttpPut("{Id}")]
        public async Task<BookUpdateResponse> UpdateResponse(int id,BookUpdateRequest request) 
        { 
            return await _bookServices.UpdateBook(id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> DeleteBook(int id) 
        { 
            return await _bookServices.DeleteBook(id);
        }

    }
}
