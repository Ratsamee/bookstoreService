using System.ComponentModel.DataAnnotations;

namespace bookstoreService.Model
{
    public class SignIn
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Password { get; set; }
    }

    public class SignInUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
