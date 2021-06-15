using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors

{
    //This class creates a UNIFORM api error message for the provided error status codes
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Not Authorized",
                404 => "Not Found",
                500 => "Server Error. Debugging Time",
                _ => null
            };

        }
    }
}
