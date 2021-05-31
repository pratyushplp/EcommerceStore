using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Core.Wrappers;
using Infrastructure.Repositories;
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
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepositoryAsync<Product> _GenericRepositoryAsync;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepositoryAsync<Product> GenericRepositoryAsync, IMapper mapper)
        {
            _GenericRepositoryAsync = GenericRepositoryAsync;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            //commented out genericRepo function without the implementation of specificaiton
            //var response = await _GenericRepositoryAsync.GetAllAsync();

            var specs = new ProductWithBrandAndTypeSpecification();
            var response = await _GenericRepositoryAsync.GetAllWithSpecsAsync(specs);
            ServiceResponse<IReadOnlyList<ProductReadDto>> finalResponse =  new ServiceResponse<IReadOnlyList<ProductReadDto>>();
            if (response.Data == null) return NotFound(response);

            finalResponse.Message = response.Message;
            finalResponse.Success = response.Success;
            finalResponse.Data = _mapper.Map<IReadOnlyList<ProductReadDto>>(response.Data);
            return Ok(finalResponse);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            //commented out genericRepo function without the implementation of specificaiton
            //var response = await _GenericRepositoryAsync.GetByIdAsync(id);
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var response = await _GenericRepositoryAsync.GetByIdWithSpecAsync(spec);
            if (response.Data == null) return NotFound(response);

            ServiceResponse<ProductReadDto> finalResponse = new ServiceResponse<ProductReadDto>();
            finalResponse.Message = response.Message;
            finalResponse.Success = response.Success;
            finalResponse.Data = _mapper.Map<ProductReadDto>(response.Data);

            return Ok(finalResponse);
        }



    }
}
