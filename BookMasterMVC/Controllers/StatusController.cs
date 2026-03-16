using Microsoft.AspNetCore.Mvc;

namespace BookMasterMVC.Controllers;

public class StatusController : Controller
{
    // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }

    // Create Status
    public IActionResult Create()
    {
        return View();
    }
    
    // Update Status
    public IActionResult Update(int id)
    {
        return View();
    }
}