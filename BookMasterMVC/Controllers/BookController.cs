using BookMasterMVC.Data;
using Microsoft.AspNetCore.Mvc;
using BookMasterMVC.Models;

namespace BookMasterMVC.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }
    
    // GET Books
    public IActionResult Index()
    {
        var books = _repository.GetAllBooks();
        return View(books);
    }
    
    // View Book
    public IActionResult ViewBook(int id)
    {
        var book = _repository.GetBook(id);
        return View(book);
    }
    
    // Update Book
    public IActionResult Update(int id)
    {
        var book = _repository.GetBook(id);
        if (book == null)
        {
            return View("BookNotFound");
        }
        
        return View(book);
    }
    
    // Update Book in Database
    public IActionResult UpdateBookToDatabase(Book book)
    {
        _repository.UpdateBook(book);

        return RedirectToAction("ViewBook", new { id = book.BookID });
    }
    
    // Create Book Form View
    public IActionResult InsertBook()
    {
        var book = _repository.AssignStatus();
        return View(book);
    }
    
    // Create Book
    public IActionResult InsertBookToDatabase(Book book)
    {
        _repository.InsertBook(bookToInsert);
        return RedirectToAction("Index");
    }
    
    // Delete Book
    public IActionResult DeleteBook(Book book)
    {
        _repository.DeleteBook(book);
        return RedirectToAction("Index");
    }
}