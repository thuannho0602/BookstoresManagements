using BookstoresManagements.Models.Publisher;
using BookstoresManagements.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoresManagements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : BaseController
    {
        private readonly IPublisherService _publisherService;
        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [HttpGet]
        public async Task<IEnumerable<PublisherGetResponse>> GetAll()
        {
            return await _publisherService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<PublisherGetResponse> Get(int id)
        {
            return await _publisherService.GetById(id);
        }

        [HttpPost]
        public async Task<PublisherCreateResponse> Create(PublisherCreateRequest request)
        {
            return await _publisherService.CreatePublisher(request);
        }

        [HttpPut("{Id}")]
        public async Task<PublisherUpdateResponse>Update(int id, PublisherUpdateRequest request)
        {
            return await _publisherService.UpdatePublisher(id, request);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int id)
        {
            return await _publisherService.DeletePublisher(id);
        }
    }
}
