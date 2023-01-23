using Microsoft.AspNetCore.Identity;

namespace IndigoBilet1.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
