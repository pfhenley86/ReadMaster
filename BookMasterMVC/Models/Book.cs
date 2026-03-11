namespace BookMasterMVC.Models;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    
    public string ImageLink { get; set; }
    public int StatusID { get; set; }
    public int Quantity { get; set; }
    public bool IsOwned { get; set; }
    public IEnumerable<Status> Status { get; set; }
}