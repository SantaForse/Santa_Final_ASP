using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.Models.Identity;

namespace Santa_Final_ASP.Controllers;

public class LogoutController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LogoutController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }


    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
        }

        return RedirectToAction("Index", "Home");
    }
}
