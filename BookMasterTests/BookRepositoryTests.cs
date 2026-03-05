using BookMasterMVC.Data;
using BookMasterMVC.Models;

namespace BookMasterTests;

public class BookRepositoryTests
{
    // Test GetAll Repo Method Ris not Null. This behavior should always be true.
    [Fact]
    public void GetAll_ReturnsAListOfBooks()
    {
        // Arrange
        var repo = new BookRepository();

        // Act
        var books = repo.GetAll();

        // Assert
        Assert.NotNull(books);
    }
    
    // Testt GetAll returns at least one books
    [Fact]
    public void GetAll_ReturnsAtLeastOneBook()
    {
        // Arrange
        var repo = new BookRepository();
        
        // Act
        var books = repo.GetAll();
        
        // Assert
        Assert.NotEmpty(books);
    }
    
    // Test Book can be assigned a Status.
    [Theory]
    [InlineData("Reading")]
    [InlineData("Read")]
    [InlineData("ToRead")]
    public void Book_Status_CanBeAssigned(string status)
    {
        // Arrange & Act
        var book = new Book() { Status = status };

        // Assert
        Assert.Equal(status, book.Status);
    }
    
    // Test if a book can be added
    [Fact]
    public void Add_AddsBookToRepository()
    {
        // Arrange
        var repo = new BookRepository();
        
        var book = new Book
        {
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt",
            Status = "Reading"
        };
        
        repo.Add(book);
        
        // Act
        var books = repo.GetAll();
        
        // Assert
        Assert.Contains(books, b => b.Title == "The Pragmatic Programmer");
    }
}