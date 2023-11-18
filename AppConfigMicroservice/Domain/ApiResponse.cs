using Microsoft.EntityFrameworkCore.Metadata;

namespace AppConfigMicroservice.Domain
{
    public class ApiResponse
    {
        public IModel Data { get; set; }
        public bool IsSuccess { get; set; } = false;

        public string? ErrorCode { get; set; }

        public List<string>? ErrorMessageList { get; set; }

        public string? ErrorMessage { get; set; }

    }
}
