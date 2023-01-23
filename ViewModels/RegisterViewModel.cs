using System.ComponentModel.DataAnnotations;

namespace IndigoBilet1.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 50)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 79),DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        [StringLength(maximumLength: 50), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 20,MinimumLength =8), DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(maximumLength: 20,MinimumLength =8), DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
