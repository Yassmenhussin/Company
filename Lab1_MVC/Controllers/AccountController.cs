using Lab1_MVC.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_MVC.Controllers
{
    public class AccountController : Controller
    {
        //Account/login?id=5&username=YYYYY || query String
        //Account/login/6?&username=YYYYYY
        //Account/login?username=YYYYYYY&id=7
        //account?username=8
        public IActionResult Login(LoginRequest login)
        {

            TempData["id"] = login.id;
            TempData["id"] = "12345";
            HttpContext.Session.SetString("userName", login.userName);
            return View();
        }
    }
}
