using Microsoft.AspNetCore.Mvc;

namespace PhotoFolioHub.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
