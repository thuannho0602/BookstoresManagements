using BookstoresManagements.Models.Genre;

namespace BookstoresManagements.Services
{
    public interface IGenreSevices
    {
        Task<List<GenreGetResponse>> GetAll();
        Task<GenreGetResponse> GetById(int Id);
        Task<GenreCreateResponse> CreateGenre(GenreCreateRequest request);
        Task<GenreUpdateResponse> UpdateGenre(int Id, GenreUpdateRequest request);
        Task<bool>DeleteGenre(int Id);
    }
}
