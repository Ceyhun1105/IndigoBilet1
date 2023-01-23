using IndigoBilet1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndigoBilet1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserManageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManageController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
/*        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser
            {
                FullName = "Ceyhun Farzullayev",
                UserName = "Ceyhun1105"
            };

            var result = await _userManager.CreateAsync(admin, "Ceyhun1105");
            return Ok(result);
        }*/

        /*public async Task<IActionResult> CreateRoles()
        {
            //IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");
            var result = await _roleManager.CreateAsync(role2);
            return Ok(result);
        }*/

       /* public async Task<IActionResult> SetRole()
        {
            AppUser user = await _userManager.FindByNameAsync("Ceyhun1105");
            var result = await _userManager.AddToRoleAsync(user, "Admin");
            return Ok(result);
        }*/
    }
}
