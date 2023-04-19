using System.ComponentModel.DataAnnotations;

namespace _01_ASPNetMVC.Models
{
    public class ContactsFormModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; } = null!;
    }

}
