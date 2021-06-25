using API.Dtos;
using API.Errors;
using API.Helpers;
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

    public class ProductController : ApiBaseController
    {
        private readonly IGenericRepositoryAsync<Product> _GenericRepositoryAsync;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepositoryAsync<Product> GenericRepositoryAsync, IMapper mapper)
        {
            _GenericRepositoryAsync = GenericRepositoryAsync;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            //commented out genericRepo function without the implementation of specificaiton
            //var response = await _GenericRepositoryAsync.GetAllAsync();

            var specs = new ProductWithBrandAndTypeSpecification(productSpecParams);
            var countSpecs = new ProductCountSpecification(productSpecParams);
            var response = await _GenericRepositoryAsync.GetAllWithSpecsAsync(specs);
            if (response == null) return NotFound(response);
            int count = await _GenericRepositoryAsync.GetCountAsync(countSpecs);
            var data =_mapper.Map<IReadOnlyList<ProductReadDto>>(response);

            return Ok(new Pagination<ProductReadDto>(productSpecParams.PageIndex, productSpecParams.PageSize, count, data));

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)] // for Swagger documentation porpse, telling the possible response outcome codes 

        public async Task<IActionResult> GetProductById(int id)
        {
            //commented out genericRepo function without the implementation of specificaiton
            //var response = await _GenericRepositoryAsync.GetByIdAsync(id);
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var response = await _GenericRepositoryAsync.GetByIdWithSpecAsync(spec);
            if (response == null) return NotFound(response);
            return Ok(_mapper.Map<ProductReadDto>(response));
        }



    }
}
