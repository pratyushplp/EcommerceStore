using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    // To handle server excception errors
    public class ApiExceptionResponse : ApiErrorResponse
    {

        public ApiExceptionResponse(int statusCode, string message = null,string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }

    }
}
