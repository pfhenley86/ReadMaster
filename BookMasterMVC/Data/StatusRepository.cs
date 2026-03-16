using System.Data;
using BookMasterMVC.Models;
using Dapper;

namespace BookMasterMVC.Data;

public class StatusRepository : IStatusRepository
{
    private readonly IDbConnection _connection;

    public StatusRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    //Add get status for creation form
    
    // Create
    public void InsertStatus(Status statusToInsert)
    {
        _connection.Execute("INSERT INTO status (statusName) VALUES (@statusName);", 
            new { statusToInsert.StatusName });
    }

    // Update
    public void UpdateStatus(Status status)
    {
        _connection.Execute("UPDATE status SET statusName=@statusName WHERE statusID=@statusID;",
            new { status = status.StatusName, statusID = status.StatusID });
    }
    
    // Delete
    public void DeleteStatus(Status status)
    {
        _connection.Execute("DELETE FROM status WHERE statusID=@statusID;", new { statusID = status.StatusID });
    }
}