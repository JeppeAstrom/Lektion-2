namespace _01_ASPNetMVC.Models
{
    public class CollectionModel
    {
        public string Title { get; set; } = null!;

        public List<CollectionItemModel> CollectionItems { get; set; } = null!;


    }
}
