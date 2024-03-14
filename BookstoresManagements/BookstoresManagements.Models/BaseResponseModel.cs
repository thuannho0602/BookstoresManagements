using BookstoresManagements.Models.Enums;

namespace BookstoresManagements.Models
{
    public class BaseResponseModel
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }

    public class BaseResponseModel<T> : BaseResponseModel where T : class
    {
        public T Data { get; set; }
    }
}
