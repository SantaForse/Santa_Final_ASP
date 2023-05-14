using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class SignupController : Controller
{
    public IActionResult Index()
    {

        ViewData["Title"] = "Signup";
        return View();
    }
}
