using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public interface IBookRepository
{
    public IEnumerable<Book> GetAllBooks();
    public Book GetBook(int id);
    public void InsertBook(Book book);
    public void UpdateBook(Book book);
    public void DeleteBook(Book book);
}