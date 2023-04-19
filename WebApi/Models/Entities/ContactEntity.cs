using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Comment { get; set; } = null!;
    }
}
