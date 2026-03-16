using BookMasterMVC.Data;
using BookMasterMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMasterMVC.Controllers;

public class StatusController : Controller
{
    private readonly IStatusRepository _repository;
    private readonly IConfiguration _configuration;

    public StatusController(IStatusRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }
    
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
    public IActionResult InsertStatusToDatabase(Status status)
    {
        if (status.StatusName != null && status.StatusName.Length > 100)
        {
            status.StatusName = status.StatusName.Substring(0, 100);
        }

        _repository.InsertStatus(status);

        return RedirectToAction("Books/Index");
    }
    
    // Create Update Staus Form View
    public IActionResult Update(int id)
    {
        var status = _repository.GetBookStatus(id);
        if (status == null)
        {
            return View("StatusNotFound");
        }
        
        return View(status);
    }
    
    // Update Book in Database
    public IActionResult UpdateStatusToDatabase(Status status)
    {
        _repository.UpdateStatus(status);

        return RedirectToAction("Books/Index");
    }
}