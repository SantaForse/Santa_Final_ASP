using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Santa_Final_ASP.Models.Contexts;
using Santa_Final_ASP.Models.Entities;
using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.ViewModels;
using Santa_Final_ASP.Services;

namespace Santa_Final_ASP.Controllers;

public class SignupController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    private readonly UserManager<AppUser> _userManager;

    private readonly IdentityContext _identityContext;

    private readonly SeedService _seedService;


    public SignupController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IdentityContext identityContext, SeedService seedService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _identityContext = identityContext;
        _seedService = seedService;
    }



    [HttpGet]
    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

            if (await _userManager.FindByNameAsync(viewModel.Email) == null)
            {

                //Move to a service later on!!!
                bool result = false;
                try
                {
                    await _seedService.SeedRoles();
                    var roleName = "user";

                    if (!await _userManager.Users.AnyAsync())
                        roleName = "admin";
                    else
                        roleName = "user";


                    AppUser customIdentityUser = viewModel;
                    await _userManager.CreateAsync(customIdentityUser, viewModel.Password);

                    await _userManager.AddToRoleAsync(customIdentityUser, roleName);

                    AddressEntity userEntity = viewModel;
                    _identityContext.UsersInformations.Add(userEntity);
                    await _identityContext.SaveChangesAsync();
                    result = true;

                }
                catch
                {
                    result = false;
                }


                if (result == true)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                    ModelState.AddModelError("", "Something went wrong.");
            }
            else
                ModelState.AddModelError("", "A user with the same email already exists");

        }
        return View(viewModel);
    }
}
