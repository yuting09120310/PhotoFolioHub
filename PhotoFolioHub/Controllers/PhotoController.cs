using Microsoft.AspNetCore.Mvc;

namespace PhotoFolioHub.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PhotoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            string a = _hostingEnvironment.WebRootPath + "\\Uploads\\Alex\\Photos";

            List<string> getFiles = Directory.GetFiles(a).ToList();

            List<string> photos = getFiles.Select(f =>
                f.Replace(_hostingEnvironment.WebRootPath, "")
            ).ToList();

            ViewBag.UserName = "" + HttpContext.Session.GetString("UserName");
			return View(photos);
        }
    }
}
