using Smitenight.Domain.Models.Enums.StatusCodes;

namespace Smitenight.Domain.Models.Contracts.Common
{
    public class ServerResponseDto
    {
        public StatusCodeEnum StatusCode { get; set; }
        public bool IsSuccessStatusCode => StatusCode == StatusCodeEnum.Success;

        public ServerResponseDto(StatusCodeEnum statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public class ServerResponseDto<TResponse> : ServerResponseDto
    {
        public TResponse? Response { get; set; }

        public ServerResponseDto(StatusCodeEnum statusCode, TResponse? response = default) : base(statusCode)
        {
            Response = response;
        }
    }
}
