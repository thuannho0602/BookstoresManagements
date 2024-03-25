using BookstoresManagements.Entity;
using BookstoresManagements.Models.Book;
using BookstoresManagements.Reponsitory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IBookReponsitory _bookReponsitory;
        public BookServices(IBookReponsitory bookReponsitory)
        {
            _bookReponsitory = bookReponsitory;
        }

        public async Task<BookCreateResponse> CreateBook(BookCreateRequest request)
        {
            if (request.Id == 0)
            {
                var book = new Book
                {
                    NameBook = request.NameBook,
                    InventoryQuantity = request.InventoryQuantity,
                    GenreId = request.GenreId,
                    PublisherId = request.PublisherId,
                    AuthorId = request.AuthorId,
                };
                _bookReponsitory.Add(book);
                _bookReponsitory.SaveChanges();

                // LinQ Include
                var data = _bookReponsitory.FindAll()
                    .Include(x => x.Genre)
                    .Include(x => x.Publisher)
                    .Include(x => x.Author)
                    .Where(x => x.Id == book.Id).FirstOrDefault();
                var bookResponse = new BookCreateResponse
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    InventoryQuantity = book.InventoryQuantity,
                    GenreId = book.GenreId,
                    GenreName = data.Genre.NameGenre,
                    PublisherId = book.PublisherId,
                    PublisherName = data.Publisher.NamePublisher,
                    AuthorId = book.AuthorId,
                    AuthorName = data.Author.NameAuthor,
                };
                return await Task.FromResult(bookResponse);
            }
            return new BookCreateResponse();
        }


        public async Task<bool> DeleteBook(int id)
        {
           var bookId=_bookReponsitory.FindByCondition(c=>c.Id == id).FirstOrDefault();
            if(bookId != null)
            {
                _bookReponsitory.Remove(bookId);
                _bookReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        public async Task<List<BookGetResponse>> GetAll()
        {
            var bookList = _bookReponsitory.FindAll().Select(c => new BookGetResponse
            { 
                Id=c.Id,
                NameBook = c.NameBook,
                InventoryQuantity = c.InventoryQuantity,
                GenreId = c.GenreId,
                GenreName = c.Genre.NameGenre,
                PublisherId=c.PublisherId,
                PublisherName = c.Publisher.NamePublisher,
                AuthorId=c.AuthorId,
                AuthorName = c.Author.NameAuthor,
            }).ToList();
            return await Task.FromResult(bookList);
        }

        public async Task<BookGetResponse> GetById(int id)
        {
            var booId=_bookReponsitory.FindByCondition(x=>x.Id == id).Select(c=>new BookGetResponse
            {
                Id = c.Id,
                NameBook = c.NameBook,
                InventoryQuantity = c.InventoryQuantity,
                GenreId = c.GenreId,
                GenreName = c.Genre.NameGenre,
                PublisherId = c.PublisherId,
                PublisherName = c.Publisher.NamePublisher,
                AuthorId = c.AuthorId,
                AuthorName = c.Author.NameAuthor,
            }).FirstOrDefault();
            return await Task.FromResult(booId);
        }

        public async Task<BookUpdateResponse> UpdateBook(int id, BookUpdateRequest request)
        {
            if (id > 0)
            {
                var bookId = _bookReponsitory.FindByCondition(x => x.Id == id).FirstOrDefault();
                if(bookId != null)
                {
                    var book = new Book
                    {
                        NameBook = request.NameBook,
                        InventoryQuantity = request.InventoryQuantity,
                        GenreId = request.GenreId,
                        PublisherId = request.PublisherId,
                        AuthorId = request.AuthorId,

                    };
                    _bookReponsitory.Update(book);
                    _bookReponsitory.SaveChanges();

                    var data = _bookReponsitory.FindAll()
                        .Include(x => x.Genre)
                        .Include(x => x.Publisher)
                        .Include(x => x.Author)
                        .Where(x => x.Id == book.Id).FirstOrDefault();

                    var bookResponse = new BookUpdateResponse
                    {
                        Id = id,
                        NameBook = book.NameBook,
                        InventoryQuantity = book.InventoryQuantity,
                        GenreId = book.GenreId,
                        GenreName = data.Genre.NameGenre,
                        PublisherId = book.PublisherId,
                        PublisherName = data.Publisher.NamePublisher,
                        AuthorId = book.AuthorId,
                        AuthorName = data.Author.NameAuthor,
                    };
                    return await Task.FromResult(bookResponse);
                }
                return new BookUpdateResponse();
            }
            return new BookUpdateResponse();
        }
    }
}
