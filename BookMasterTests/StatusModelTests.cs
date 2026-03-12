using BookMasterMVC.Models;
namespace BookMasterTests;

public class StatusModelTests
{
    // Test Status Can Be Initialized
    [Fact]
    public void Status_CanBeInitialized_WithValues()
    {
        // Arrange
        var expectedId = 1;
        var expectedStatusName = "Read";

        // Act
        var status = new Status
        {
            StatusID = expectedId,
            StatusName = expectedStatusName
        };

        // Assert
        Assert.Equal(expectedId, status.StatusID);
        Assert.Equal(expectedStatusName, status.StatusName);
    }

    [Theory]
    [InlineData(1, "Read")]
    [InlineData(2, "Reading")]
    public void Status_InitializationWithInlineData_ChecksProperties(int id, string statusName)
    {
        // Act
        var status = new Status
        {
            StatusID = id,
            StatusName = statusName
        };

        // Assert
        Assert.Equal(id, status.StatusID);
        Assert.Equal(statusName, status.StatusName);
    }
}