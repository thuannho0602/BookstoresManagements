using BookstoresManagements.Entity;
using BookstoresManagements.Models.Genre;
using BookstoresManagements.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class GenreServices : IGenreSevices
    {
        private readonly IGenreReponsitory _genreReponsitory;
        public GenreServices(IGenreReponsitory genreReponsitory)
        {
            _genreReponsitory = genreReponsitory;
        }

        public async Task<GenreCreateResponse> CreateGenre(GenreCreateRequest request)
        {
            if (request.Id == 0)
            {
                var genre = new Genre
                {
                    NameGenre = request.NameGenre,
                };
                _genreReponsitory.Add(genre);
                _genreReponsitory.SaveChanges();
                var genreResponse = new GenreCreateResponse
                {
                    Id = genre.Id,
                    NameGenre = request.NameGenre,
                };
                return await Task.FromResult(genreResponse);
            }
            return new GenreCreateResponse();
        }

        public async Task<bool> DeleteGenre(int Id)
        {
           var deleteItemGenre=_genreReponsitory.FindByCondition(c=>c.Id == Id).FirstOrDefault();
            if(deleteItemGenre != null)
            {
                _genreReponsitory.Remove(deleteItemGenre);
                _genreReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;

        }

        public Task<List<GenreGetResponse>> GetAll()
        {
            var listGenre = _genreReponsitory.FindAll().Select(c => new GenreGetResponse
            {
                Id = c.Id,
                NameGenre = c.NameGenre,
            }).ToList();
            return Task.FromResult(listGenre);
        }

        public async Task<GenreGetResponse> GetById(int Id)
        {
           var genreId=_genreReponsitory.FindByCondition(x=>x.Id == Id).Select(c=>new GenreGetResponse
           {
               Id = c.Id,
               NameGenre = c.NameGenre,
           }).FirstOrDefault();
            return await Task.FromResult(genreId);
        }

        public async Task<GenreUpdateResponse> UpdateGenre(int Id, GenreUpdateRequest request)
        {
            if (Id > 0)
            {
                var genreId=_genreReponsitory.FindByCondition(c=>c.Id==Id).FirstOrDefault();
                if (genreId != null)
                {
                    var genre = new Genre
                    {
                        Id = Id,
                        NameGenre = request.NameGenre,
                    };
                    _genreReponsitory.Update(genre);
                    _genreReponsitory.SaveChanges();

                    var genreResponse = new GenreUpdateResponse
                    {
                        Id = Id,
                        NameGenre = genre.NameGenre,
                    };
                    return await Task.FromResult(genreResponse);
                }
                return new GenreUpdateResponse();
            }
            return new GenreUpdateResponse();
        }
    }
}
