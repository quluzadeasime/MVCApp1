using Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBilet1.DTO_s.AccountDTO;

namespace MVCBilet1.Controllers
{
    public class AccountController : Controller
    {
       //private readonly UserManager<User> userManager;

        //public AccountController(UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //}
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View();
            return Json(registerDto);
        }
    }
}
