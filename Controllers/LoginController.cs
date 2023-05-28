using Santa_Final_ASP.Services;
using Santa_Final_ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class LoginController : Controller
{

    private readonly AuthenticationService _auth;

    public LoginController(AuthenticationService auth)
    {
        _auth = auth;
    }

    [HttpGet]
    public IActionResult Index(string ReturnUrl = null!)
    {
        var viewmodel = new UserLoginViewModel();
        if (ReturnUrl != null)
            viewmodel.ReturnUrl = ReturnUrl;

        return View(viewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserLoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.LogInAsync(viewModel))
                return LocalRedirect(viewModel.ReturnUrl);

            ModelState.AddModelError("", "Incorrect Email och Password");
        }
        return View(viewModel);

    }
}
