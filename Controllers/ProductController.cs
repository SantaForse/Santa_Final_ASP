using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Product";
        return View();
    }

}
