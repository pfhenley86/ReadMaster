using BookMasterMVC.Data;
using BookMasterMVC.Models;
using MySql.Data.MySqlClient;

namespace BookMasterTests;

public class BookRepositoryTests
{
    // Test GetAll Repo Method Ris not Null. This behavior should always be true.
    [Fact]
    public void GetAllBooks_ReturnsAListOfBooks()
    {
        // Arrange
        // Get your connection string (from a config file or hardcoded for the final)
        string connString = "server=localhost;database=BookMaster;user=root;password=password";
    
        // Create the MySQL connection object the constructor is asking for
        using var connection = new MySqlConnection(connString);
    
        // Pass it into the repository to satisfy the constructor
        var repo = new BookRepository(connection);

        // Act
        var books = repo.GetAllBooks();

        // Assert
        Assert.NotNull(books);
    }
    
    // Testt GetAll returns at least one books
    [Fact]
    public void GetAllBooks_ReturnsAtLeastOneBook()
    {
        // Arrange
        // Get your connection string (from a config file or hardcoded for the final)
        string connString = "server=localhost;database=BookMaster;user=root;password=password";
    
        // Create the MySQL connection object the constructor is asking for
        using var connection = new MySqlConnection(connString);
    
        // Pass it into the repository to satisfy the constructor
        var repo = new BookRepository(connection);
        
        // Act
        var books = repo.GetAllBooks();
        
        // Assert
        Assert.NotEmpty(books);
    }
    
    //Test Book can be assigned a Status.
    // [Theory]
    // [InlineData("Reading")]
    // [InlineData("Read")]
    // [InlineData("ToRead")]
    // public void Book_Status_CanBeAssigned(string status)
    // {
    //     // Arrange & Act
    //     var book = new Book() { Status = status };
    //
    //     // Assert
    //     Assert.Equal(status, book.Status);
    // }
}