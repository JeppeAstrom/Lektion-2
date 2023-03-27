namespace _01_ASPNetMVC.Models
{
    public class CollectionItemModel
    {
        public string ID { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
    }

}