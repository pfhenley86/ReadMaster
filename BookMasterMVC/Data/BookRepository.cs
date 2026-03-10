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
        throw new NotImplementedException();
    }

    public void InsertBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }
}