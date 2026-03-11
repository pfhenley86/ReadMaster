using System.Data;
using BookMasterMVC.Models;
using Dapper;

namespace BookMasterMVC.Data;

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _connection;

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

    /**ToDo */
    public void InsertBook(Book bookToInsert)
    {
       _connection.Execute("INSERT INTO books (TITLE, AUTHOR, STATUS) VALUES (@title, @author, @statusID);",
           new { title = bookToInsert.Title, author = bookToInsert.Author, bookID = bookToInsert.BookID });
    }

    public void UpdateBook(Book book)
    {
        _connection.Execute("UPDATE books SET Title = @title, Author = @author WHERE BookID = @bookID;", 
            new { book.Title, book.Author, bookID = book.BookID });
    }

    public IEnumerable<Status> GetStatus()
    {
        return _connection.Query<Status>("SELECT * FROM status");
    }

    public Book AssignStatus()
    {
        var statusList = GetStatus();
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