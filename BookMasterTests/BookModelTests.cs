using BookMasterMVC.Models;

namespace BookMasterTests;

public class BookModelTests
{
    // Test Book Can Be Initialized
    [Fact]
    public void Book_CanBeInitializedWithValues()
    {
        // Arrange
        var expectedId = 1;
        var expectedTitle = "Test Title";
        var expectedAuthor = "Test Author";

        // Act
        var book = new Book
        {
            BookID = expectedId,
            Title = expectedTitle,
            Author = expectedAuthor
        };

        // Assert
        Assert.Equal(expectedId, book.BookID);
        Assert.Equal(expectedTitle, book.Title);
        Assert.Equal(expectedAuthor, book.Author);
    }

    [Theory]
    [InlineData(1, "Test Title", "Test Author")]
    [InlineData(2, "Test Title Two", "Test Author Two")]
    public void Book_InitializationWithInLineData_ChecksProperties(int id, string title, string author)
    {
        // Act
        var book = new Book
        {
            BookID = id,
            Title = title,
            Author = author
        };

        // Assert
        Assert.Equal(id, book.BookID);
        Assert.Equal(title, book.Title);
        Assert.Equal(author, book.Author);
    }
}