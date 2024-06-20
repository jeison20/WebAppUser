using System.ComponentModel.DataAnnotations;

namespace WebAppUser.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [RegularExpression(@"^[0-9,$]*$", ErrorMessage = "Document number are not valid.")]        
        public string Document { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z ]{2,254}", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
