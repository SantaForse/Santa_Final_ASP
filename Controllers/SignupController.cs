using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.ViewModels;
using Santa_Final_ASP.Services;
using Microsoft.AspNetCore.Authentication;

namespace Santa_Final_ASP.Controllers;

public class SignupController : Controller
{
    private readonly Services.AuthenticationService _verify;

    public SignupController(Services.AuthenticationService verify)
    {
        _verify = verify;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
    {

        if (ModelState.IsValid)
        {
            if (await _verify.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
            {
                ModelState.AddModelError("", "A user with this email already exists.");
                return View(viewModel);
            }

            if (await _verify.RegisterUserAsync(viewModel))
            {
                return RedirectToAction("index", "login");
            }
        }
        return View(viewModel);
    }

}
