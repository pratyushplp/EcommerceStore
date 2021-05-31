using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IGenericRepositoryAsync<ProductBrand> _GenericRepositoryAsync;

        public ProductBrandController(IGenericRepositoryAsync<ProductBrand> GenericRepositoryAsync)
        {
            _GenericRepositoryAsync = GenericRepositoryAsync;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _GenericRepositoryAsync.GetAllAsync();
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _GenericRepositoryAsync.GetByIdAsync(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }



    }
}
