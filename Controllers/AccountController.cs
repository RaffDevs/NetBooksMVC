using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using NetBooksMVC.ViewModels;

namespace NetBooksMVC.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {

        return View(new LoginViewModel
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(loginViewModel);
        }

        var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(loginViewModel.ReturnUrl);
            }
        }

        ModelState.AddModelError("", "Erro ao realizar login");
        return View(loginViewModel);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginViewModel registerVM)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = registerVM.UserName };
            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                registerVM.errorView = new ErrorMessagesViewModel
                {
                    errorMessages = result.Errors.Select(e => e.Description)
                };
            }
        }
        else
        {
            IEnumerable<string> errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage);

            registerVM.errorView = new ErrorMessagesViewModel
            {
                errorMessages = errors
            };
        }

        return View(registerVM);

    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}