using System.Data;
using BookMasterMVC.Models;
using Dapper;

namespace BookMasterMVC.Data;

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _connection;
    
    // Default constructor for testing Repo
    public BookRepository() 
    {
        // Initialize your connection string/connection here if it's not already
    }


    public BookRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _connection.Query<Book>("SELECT * FROM books");
    }

    public Book GetBook(int id)
    {
        return _connection.QuerySingle<Book>("SELECT * FROM books WHERE BookID = @id;", new { id });
    }
    
    public void InsertBook(Book bookToInsert)
    {
        _connection.Execute(
            "INSERT INTO books (Title, Author, Description, ImageLink, Quantity, IsOwned, StatusID) VALUES (@Title, @Author, @Description, @ImageLink, Quantity, IsOwned, @StatusID);",
            new { bookToInsert.Title, bookToInsert.Author, bookToInsert.Description, bookToInsert.ImageLink, bookToInsert.Quantity, bookToInsert.IsOwned, bookToInsert.StatusID
            });
    }

    public void UpdateBook(Book book)
    {
        _connection.Execute(
            @"UPDATE Books SET Title = @Title,Author = @Author, Description = @Description,ImageLink = @ImageLink, Quantity = @Quantity,IsOwned = @IsOwned,
            StatusID = @StatusID WHERE BookID = @BookID;", new { book.Title, book.Author, book.Description, book.ImageLink, book.Quantity, book.IsOwned, book.StatusID, book.BookID});
    }

    public List<Status> GetStatuses()
    {
        return _connection.Query<Status>("SELECT StatusID, StatusName FROM Status").ToList();
    }

    public Book AssignStatus()
    {
        var statusList = GetStatuses();
        var book = new Book();
        book.Status = statusList;
        return book;
    }

    // Status Methods

    public void DeleteBook(Book book)
    {
        _connection.Execute("DELETE From books WHERE BookID = @bookID;", new { book.BookID });
    }
}