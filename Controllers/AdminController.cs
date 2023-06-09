﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Santa_Final_ASP.Services.Repo;
using Santa_Final_ASP.ViewModels;

namespace Santa_Final_ASP.Controllers;

public class AdminController : Controller
{
    private readonly UserRepository _userRepository;

    public AdminController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new UsersViewModel
        {
            Users = await _userRepository.GetAllAsync()
        };
        return View(viewModel);

    }
}
