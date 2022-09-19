using GeekShopping.teste.Data.ValueObjects;
using GeekShopping.teste.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace teste.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class testeController : ControllerBase
    {
        private readonly ILogger<testeController> _logger;
        private ICartRepository _repository;
        public testeController(ILogger<testeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            return null;
            
        }

        [HttpPost]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }



    }

    
}
