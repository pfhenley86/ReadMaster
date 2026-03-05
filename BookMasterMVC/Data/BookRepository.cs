using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public class BookRepository : IBookRepository
{
    public List<Book> _books = new List<Book>
    {
        new Book { Title = "Clean Code", Author = "Robert C. Martin", Status = "Read" }
    };

    public List<Book> GetAll()
    {
        return _books;
    }

    public void Add(Book book)
    {
        _books.Add(book);
    }
}