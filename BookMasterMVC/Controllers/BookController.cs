using Microsoft.AspNetCore.Mvc;

namespace BookMasterMVC.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}