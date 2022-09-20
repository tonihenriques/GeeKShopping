using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class testeController : Controller
    {
        private readonly Iteste _testeService;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public testeController(Iteste testeService, IProductService productService, ICartService cartService)
        {
            _testeService = testeService;
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> testeIndex()
        {
            var products = await _testeService.FindAllProducts();
            return View(products);
        }

        [Authorize]
        public async Task<IActionResult> Details()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var cart = new CartViewModel();

            var response = await _cartService.AddItemToCart(cart, token);

            return View();
        }
    }
}
