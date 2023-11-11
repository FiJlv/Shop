using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Models;
using Shop.ViewModels;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AuthController : Controller
    {
        private const string index = "Index";
        private const string adminPanel = "AdminPanel";
        private const string home = "Home";

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await signInManager.PasswordSignInAsync(vm.UserName, vm.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return View(vm);
            }

            var user = await userManager.FindByNameAsync(vm.UserName);

            var isAdmin = await userManager.IsInRoleAsync(user, "Admin");

            if (isAdmin)
            {
                return RedirectToAction(index, adminPanel);
            }

            return RedirectToAction(index, home);

        }
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) 
            {
                return View(vm);
            }

            var user = new User
            {
                UserName = vm.Name, 
                Surname = vm.Surname,
                Email = vm.Email,
                PhoneNumber = vm.Phone,
                Address = vm.Address
            };

            var result = await userManager.CreateAsync(user, vm.Password);

            if(result.Succeeded) 
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction(index, home);
            }

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(index, home);
        }
    }
}
