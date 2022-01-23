using System.Collections.Generic;
using coredapperapi.Model;

namespace coredapperapi.Response
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}