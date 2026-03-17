using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public interface IBookRepository
{
    public IEnumerable<Book> GetAllBooks();
    public Book GetBook(int id);
    public void InsertBook(Book bookToInsert);
    public void UpdateBook(Book book);
    public List<Status> GetStatuses();
    public Book AssignStatus();
    public void DeleteBook(Book book);
}