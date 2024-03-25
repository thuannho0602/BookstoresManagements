using BookstoresManagements.Entity;
using BookstoresManagements.Models.Publisher;
using BookstoresManagements.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services.Implementations
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherReponsitory _publisherReponsitory;
        public PublisherService(IPublisherReponsitory publisherReponsitory)
        {
            _publisherReponsitory = publisherReponsitory;
        }

        public async Task<PublisherCreateResponse> CreatePublisher(PublisherCreateRequest request)
        {
            if(request.Id== 0)
            {
                var publisher = new Publisher
                {
                    NamePublisher = request.NamePublisher,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                };
                _publisherReponsitory.Add(publisher);
                _publisherReponsitory.SaveChanges();

                var pulisherReponse = new PublisherCreateResponse
                {
                    Id = publisher.Id,
                    NamePublisher = publisher.NamePublisher,
                    Address = publisher.Address,
                    PhoneNumber = publisher.PhoneNumber,
                    Email = publisher.Email,
                };
                return await Task.FromResult(pulisherReponse);
            }
            return new PublisherCreateResponse();
        }

        public async Task<bool> DeletePublisher(int id)
        {
           var publisherId=_publisherReponsitory.FindByCondition(c=>c.Id==id).FirstOrDefault();
            if(publisherId!= null)
            {
                _publisherReponsitory.Remove(publisherId);
                _publisherReponsitory.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        public async Task<List<PublisherGetResponse>> GetAll()
        {
           var getPublisher=_publisherReponsitory.FindAll().Select(c=>new PublisherGetResponse
           {
               Id=c.Id,
               NamePublisher=c.NamePublisher,
               Address = c.Address,
               PhoneNumber = c.PhoneNumber,
               Email = c.Email,
           }).ToList();
            return await Task.FromResult(getPublisher);
        }

        public async Task<PublisherGetResponse> GetById(int id)
        {
            var getIdPublisher=_publisherReponsitory.FindByCondition(x=>x.Id==id).Select(c=>new PublisherGetResponse
            {
                Id = c.Id,
                NamePublisher = c.NamePublisher,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
            }).FirstOrDefault();
            return await Task.FromResult(getIdPublisher);
        }

        public async Task<PublisherUpdateResponse> UpdatePublisher(int id, PublisherUpdateRequest request)
        {
            if (id > 0)
            {
                var publisherId = _publisherReponsitory.FindByCondition(c => c.Id == id).FirstOrDefault();
                if(publisherId != null)
                {
                    var publisher = new Publisher
                    {
                        Id = id,
                        NamePublisher = request.NamePublisher,
                        Address = request.Address,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                    };
                    _publisherReponsitory.Update(publisher);
                    _publisherReponsitory.SaveChanges();
                    var publisherResponse = new PublisherUpdateResponse
                    {
                        Id = id,
                        NamePublisher = publisher.NamePublisher,
                        Address = publisher.Address,
                        PhoneNumber = publisher.PhoneNumber,
                        Email = publisher.Email,
                    };
                    return await Task.FromResult(publisherResponse);
                }
                return new PublisherUpdateResponse();
            }
            return new PublisherUpdateResponse();
        }
    }
}
