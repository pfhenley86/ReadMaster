using BookMasterMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BookMasterMVC.Models;
using Newtonsoft.Json;
using System.Linq;

namespace BookMasterMVC.Controllers;

public class BooksController : Controller
{
    private readonly IBookRepository _repository;

    public BooksController(IBookRepository repository)
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
    public IActionResult InsertBook(string title, string author)
    {
        var book = _repository.AssignStatus();

        book.Title = title;
        book.Author = author;
        
        return View(book);
    }
    
    // Create Book
    public IActionResult InsertBookToDatabase(Book bookToInsert)
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
    
    // Search for Books
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Search(string query)
    {
        var url = $"https://www.googleapis.com/books/v1/volumes?q={query}";

        using (var client = new WebClient())
        {
            var json = client.DownloadString(url);
            var result = JsonConvert.DeserializeObject <GoogleBooksResponse>(json);
            
            if (result == null || result.Items == null || result.Items.Count == 0)
            {
                ViewBag.Message = "No books found.";
                return View();
            }
            
            var book = result?.Items?.First()?.VolumeInfo;
            return View(book);
        }
    }
}