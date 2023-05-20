using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
