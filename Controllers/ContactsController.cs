using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.ViewModels;
using Santa_Final_ASP.Services;

namespace Santa_Final_ASP.Controllers;

public class ContactsController : Controller
{
    private readonly MessageService _messageService;

    public ContactsController(MessageService messageService)
    {
        _messageService = messageService;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _messageService.RegisterMessageAsync(viewModel))
            {
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(viewModel);
            }

        }
        return View(viewModel);
    }
}
