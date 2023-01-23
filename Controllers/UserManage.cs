using IndigoBilet1.Models;
using IndigoBilet1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndigoBilet1.Controllers
{
    public class UserManage : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserManage(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModel memberVM)
        {
            if (!ModelState.IsValid) return View(memberVM);
            var user = await _userManager.FindByNameAsync(memberVM.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Password is invalid");
                return View(memberVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, memberVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is invalid");
                return View(memberVM);
            }

            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByNameAsync(registerVM.UserName);

            if (user != null)
            {
                ModelState.AddModelError("UserName", "Already Exist");
                return View(registerVM);
            }

            var user1 = await _userManager.FindByEmailAsync(registerVM.Email);

            if (user1 != null)
            {
                ModelState.AddModelError("Email", "Already Exist");
                return View(registerVM);
            }

            AppUser member = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                FullName = registerVM.FullName,
            };
           

            var result = await _userManager.CreateAsync(member,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View(registerVM);
                }
            }
            var result1 = await _userManager.AddToRoleAsync(member, "Member");
            if (!result1.Succeeded)
            {
                foreach (var err in result1.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                    return View(registerVM);
                }
            }

            /*await _signInManager.PasswordSignInAsync(member, registerVM.Password, false, false);*/

            return RedirectToAction("login", "userManage");

        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
    }
}
