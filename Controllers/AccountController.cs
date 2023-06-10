using EticketsWebApp.Data;
using EticketsWebApp.Data.Static;
using EticketsWebApp.Data.ViewModels;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
           var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login()=> View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user =await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result =await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                ViewData["Error"] = "Wrong credentials, please try again";
                return View(loginVM);
            }
            ViewData["Error"] = "Wrong credentials, please try again";
            return View(loginVM);
        }

        // Account/Register
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                ViewData["Error"] = "Sorry, this Email Adresse is already exist";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName=registerVM.FullName,
                Email=registerVM.EmailAddress,
                UserName=registerVM.EmailAddress
            };
            var userResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (userResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
