using System.ComponentModel.DataAnnotations;

namespace IndigoBilet1.ViewModels
{
    public class MemberLoginViewModel
    {
        [StringLength(maximumLength:50)]
        public string UserName { get; set; }
        [StringLength(maximumLength:20,MinimumLength =8),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
