using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public interface IBookRepository
{
    public IEnumerable<Book> GetAllBooks();
    public Book GetBook(int id);
    public void InsertBook(Book book);
    public void UpdateBook(Book book);
    public IEnumerable<Status> GetStatus();
    public Book AssignStatus();
    public void DeleteBook(Book book);
}