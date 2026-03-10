using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public class BookRepository : IBookRepository
{
    public List<Book> _books = new List<Book>
    {
        new Book { Title = "Clean Code", Author = "Robert C. Martin", Status = "Read" }
    };

    public IEnumerable<Book> GetAllBooks()
    {
        throw new NotImplementedException();
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