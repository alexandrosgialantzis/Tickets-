using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
