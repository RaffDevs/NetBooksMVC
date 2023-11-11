using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetBooksMVC.Usecases.Api;
using NetBooksMVC.ViewModels;

namespace NetBooksMVC.Controllers;

public class HomeController : Controller
{
    private readonly RemoteBooksUsecase _remoteBooksUsecase;

    public HomeController(RemoteBooksUsecase remoteBooksUsecase)
    {
        _remoteBooksUsecase = remoteBooksUsecase;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _remoteBooksUsecase.GetRemoteBooks();
        var viewmodel = new HomeViewModel();

        if (result.IsSuccess)
        {
            viewmodel.books = result.Data.Books;
        }
        else
        {
            viewmodel.errorMessages = new List<string>{
                result.Error.Message
            };
        }

        return View(viewmodel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
