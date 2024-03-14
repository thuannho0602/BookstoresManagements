using BookstoresManagements.Models.Genre;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : BaseController
    {
        private readonly IGenreSevices _genreSevices;
        public GenresController(IGenreSevices genreSevices)
        {
            _genreSevices = genreSevices;
        }
        [HttpGet]
        public async Task<IEnumerable<GenreGetResponse>> GetAll()
        {
            return await _genreSevices.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<GenreGetResponse> Get(int id)
        {
            return await _genreSevices.GetById(id);
        }

        [HttpPost]
        public async Task<GenreCreateResponse>Create( GenreCreateRequest genreCreateRequest)
        {
            return await _genreSevices.CreateGenre(genreCreateRequest);
        }

        [HttpPut("{Id}")]
        public async Task<GenreUpdateResponse>Update(int id, GenreUpdateRequest genreUpdateRequest)
        {
            return await _genreSevices.UpdateGenre(id, genreUpdateRequest);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int id)
        {
            return await _genreSevices.DeleteGenre(id);
        }



    }
}
