using DrivingSchoolCRM.Prototype.MVC.Data;
using DrivingSchoolCRM.Prototype.MVC.Models.User.Dtos;
using DrivingSchoolCRM.Prototype.MVC.Services.User.IUser;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolCRM.Prototype.MVC.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;

        public AuthentificationController(IUserService userService, ApplicationDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerUserDto);
            }

            var result = await _userService.RegisterUserAsync(registerUserDto);

            if (result != null && result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Login");
            }

            TempData["ErrorMessage"] = result?.Message ?? "Registration failed.";
            return View(registerUserDto);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return View(loginDto);

            var users = await _userService.GetAllUsersAsync(); 
            var user = _dbContext.Users.FirstOrDefault(u =>
                u.UserEmailAddress == loginDto.UserEmailAddress &&
                u.UserPassword == loginDto.UserPassword);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return View(loginDto);
            }

            TempData["SuccessMessage"] = $"Welcome, {user.UserFirstName}!";
            return RedirectToAction("Index", "Home");
        }
    }
}
