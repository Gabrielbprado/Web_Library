using Microsoft.AspNetCore.Mvc;
using Web_Library.Models;
using Web_Library.Services;

namespace Web_Library.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult CadastreUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastreUser(UserModel model)
        {
        
            if (ModelState.IsValid)
            {
                var res = await _userService.CreateUser(model);
                
                return RedirectToAction("Index", "Emprestimo");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserModel model)
        {
            
                var res = await _userService.LoginUser(model);
                if (res != null)
                {
                return RedirectToAction("Index", "Emprestimo");
            }
            
            return View(model);
        }
    }
}
