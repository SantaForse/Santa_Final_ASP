using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class ContactsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Contact us";

        return View();
    }
}
