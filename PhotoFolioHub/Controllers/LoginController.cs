using Microsoft.AspNetCore.Mvc;

namespace PhotoFolioHub.Controllers
{
    public class LoginController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string account, string password)
        {
			HttpContext.Session.SetString("UserName", "蔡宇庭");
			return RedirectToAction("Index", "Photo");
		}
    }
}
