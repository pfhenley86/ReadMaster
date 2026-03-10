using BookMasterMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookMasterMVC.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}