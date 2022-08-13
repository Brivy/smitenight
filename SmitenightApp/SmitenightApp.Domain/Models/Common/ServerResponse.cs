using SmitenightApp.Domain.Enums.StatusCodes;

namespace SmitenightApp.Domain.Models.Common
{
    public class ServerResponse
    {
        public StatusCodeEnum StatusCode { get; set; }
        public bool IsSuccessStatusCode => StatusCode == StatusCodeEnum.Success;

        public ServerResponse(StatusCodeEnum statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public class ServerResponse<TResponse> : ServerResponse
    {
        public TResponse? Response { get; set; }

        public ServerResponse(StatusCodeEnum statusCode) : base(statusCode)
        {
            Response = default;
        }

        public ServerResponse(StatusCodeEnum statusCode, TResponse response) : base(statusCode)
        {
            Response = response;
        }
    }
}
