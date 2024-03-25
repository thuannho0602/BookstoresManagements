using BookstoresManagements.Models.Authors;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        private readonly IAuthorServices _authorServices;
        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorGetResponse>> GetAll()
        {
           return await _authorServices.GetAllAuthor();
        }

        [HttpGet("{Id}")]
        public async Task<AuthorGetResponse>GetById(int Id)
        {
            return await _authorServices.GetByIdAuthor(Id);
        }

        [HttpPost]
        public async Task<AuthorCreateResponse>Create(AuthorCreateRequest authorCreateRequest)
        {
            return await _authorServices.CreateAuthor(authorCreateRequest);
        }

        [HttpPut("{Id}")]
        public async Task<AuthorUpdateResponse> Update(int id,AuthorUpdateRequest authorUpdateRequest)
        {
            return await _authorServices.UpdateAuthor(id,authorUpdateRequest);
        }

        [HttpDelete("{Id}")]
        public async Task<bool>Delete(int id)
        {
            return await _authorServices.DeleteAuthor(id);
        }
    }
}
