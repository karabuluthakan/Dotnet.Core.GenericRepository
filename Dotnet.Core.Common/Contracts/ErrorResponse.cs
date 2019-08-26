using System.Collections.Generic;

namespace Dotnet.Core.Common.Contracts
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}