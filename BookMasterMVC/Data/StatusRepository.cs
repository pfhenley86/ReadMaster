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
    public Status GetBookStatus(int id)
    {
        return _connection.QuerySingle<Status>("SELECT * FROM status WHERE StatusID = @id;", new { id });
    }

    public void InsertStatus(Status statusToInsert)
    {
        _connection.Execute("INSERT INTO status (statusName) VALUES (@statusName);", 
            new { statusToInsert.StatusName });
    }

    // Update
    public void UpdateStatus(Status status)
    {
        _connection.Execute("UPDATE status SET StatusName=@StatusName WHERE StatusID=@StatusID;",
            new { StatusName = status.StatusName, StatusID = status.StatusID });
    }
    
    // Delete
    public void DeleteStatus(Status status)
    {
        _connection.Execute("DELETE FROM status WHERE statusID=@statusID;", new { statusID = status.StatusID });
    }
}