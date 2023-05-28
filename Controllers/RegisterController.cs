using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.ViewModels;
using Santa_Final_ASP.Services;

namespace Santa_Final_ASP.Controllers;

public class RegisterController : Controller
{
    private readonly AuthenticationService _authenticationService;

    public RegisterController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
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
            if (await _authenticationService.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
            {
                ModelState.AddModelError("", "A user with this email already exists.");
                return View(viewModel);
            }

            if (await _authenticationService.RegisterUserAsync(viewModel))
            {
                return RedirectToAction("index", "login");
            }
        }
        return View(viewModel);
    }

}
