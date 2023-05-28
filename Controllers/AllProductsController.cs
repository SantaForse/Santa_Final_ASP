using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.Services;
using Santa_Final_ASP.ViewModels;

namespace Santa_Final_ASP.Controllers
{
    public class AllProductsController : Controller
    {
        private readonly ProductService _productService;

        public AllProductsController(ProductService productService)
        {
            _productService = productService;
        }



        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductsViewModel
            {
                Products = await _productService.GetAllProducts()
            };

            return View(viewModel);
        }
    }
}
