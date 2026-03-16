using BookMasterMVC.Models;

namespace BookMasterMVC.Data;

public interface IStatusRepository
{
    public Status GetBookStatus(int id);
    public void InsertStatus(Status statusToInsert);
    public void UpdateStatus(Status status);
    public void DeleteStatus(Status status);
}