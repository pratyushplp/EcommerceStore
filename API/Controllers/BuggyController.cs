using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class BuggyController : ApiBaseController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var response = _context.Products.Find(100);
            if (response == null) return NotFound(new ApiErrorResponse(404));
            return Ok(response);
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            //Added middleware to fix this problem
            var response = _context.Products.Find(100);
            response.ToString();
            return Ok(new ApiErrorResponse(500));
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {

            return BadRequest(new ApiErrorResponse(400));
        }
  
        [HttpGet("BadRequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            // configured ApiBehaviorOptions to fix this problem
            return Ok();
        }



    }
}
