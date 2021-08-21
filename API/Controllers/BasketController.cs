using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BasketController : ApiBaseController
    {
        private IBasketRepositoryAsync _basketRepository;
        public BasketController( IBasketRepositoryAsync basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasketById(string id)
        {
            var result = await _basketRepository.GetBasketAsync(id);
            return Ok(result ?? new Basket(id));
        }
        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket)
        {
            var result = await _basketRepository.UpdateBasketAsync(basket);
            if (result == null) return NotFound();

            return result;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasketAsync(string Id)
        {
            var result = await _basketRepository.DeleteBasketAsync(Id);
            if(!result) return NotFound();

            return Ok();
        }


    }
}
