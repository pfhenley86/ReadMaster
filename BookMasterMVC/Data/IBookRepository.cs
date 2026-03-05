using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public interface IBookRepository
{
    List<Book> GetAll();
    void Add(Book book);
}