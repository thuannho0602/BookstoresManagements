using BookstoresManagements.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public interface IPublisherService
    {
        Task<List<PublisherGetResponse>> GetAll();
        Task<PublisherGetResponse>GetById(int id);
        Task<PublisherCreateResponse> CreatePublisher(PublisherCreateRequest request);
        Task<PublisherUpdateResponse> UpdatePublisher(int id, PublisherUpdateRequest request);  
        Task<bool> DeletePublisher(int id);
    }
}
