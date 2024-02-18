using Microsoft.AspNetCore.Mvc;
using PhotoFolioHub.Models;

namespace PhotoFolioHub.Controllers
{
    public class LoginController : Controller
    {
        public readonly PhotoFolioHubContext _context;

        public LoginController(PhotoFolioHubContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            User? user = _context.Users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();

            if(user == null)
            {
                TempData["ErrorMessage"] = "登入失敗，請檢查帳號和密碼。";
                return View();
            }
            else
            {
				HttpContext.Session.SetString("UserId", user.UserId.ToString());
				HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToAction("Index", "Photo");
            }
		}


        
    }
}
