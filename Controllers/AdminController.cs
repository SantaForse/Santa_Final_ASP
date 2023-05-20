using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Santa_Final_ASP.Controllers;

public class AdminController : Controller
{
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }
}
