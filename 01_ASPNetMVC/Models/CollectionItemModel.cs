namespace _01_ASPNetMVC.Models;

public class CollectionItemModel
{
    public int ID { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public int StarRating { get; set; }

    public decimal Price { get; set; }
}