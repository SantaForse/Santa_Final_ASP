﻿using Microsoft.AspNetCore.Mvc;

namespace Santa_Final_ASP.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {

        ViewData["Title"] = "Login";
        return View();
    }
}
