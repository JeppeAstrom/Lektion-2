namespace _01_ASPNetMVC.Models.Entities
{
    public class ContactsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Comment { get; set; } = null!;
    }
}
