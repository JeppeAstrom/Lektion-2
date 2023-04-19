using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ContactEntityModel
    {

            [Required(ErrorMessage = "Please enter your name.")]
            public string Name { get; set; } = null!;

            [Required(ErrorMessage = "Please enter your Email.")]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required(ErrorMessage = "Please enter a message.")]
            public string Comment { get; set; } = null!;
        }

    

}

