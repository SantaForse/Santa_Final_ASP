using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.Services;

namespace Santa_Final_ASP.Controllers;

public class OneProductController : Controller
{
    private readonly ProductService _productService;

    public OneProductController(ProductService productService)
    {
        _productService = productService;
    }



    public IActionResult Index(Guid id)
    {
        // See if there is a product with this id
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            // If there isnt a product
            return RedirectToAction("Index", "Home");
        }

        // If there is a product, passes product to view?
        return View(product);
    }

}
