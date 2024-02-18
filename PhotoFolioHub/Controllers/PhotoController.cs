using Microsoft.AspNetCore.Mvc;
using PhotoFolioHub.Filter;
using PhotoFolioHub.Models;

namespace PhotoFolioHub.Controllers
{
	[Auth]
	public class PhotoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public readonly PhotoFolioHubContext _context;

        public PhotoController(IWebHostEnvironment hostingEnvironment, PhotoFolioHubContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }


        public IActionResult Index()
        {
            string bb = HttpContext.Session.GetString("UserName");

			string a = _hostingEnvironment.WebRootPath + "\\Uploads\\Alex\\Photos";

            List<string> getFiles = Directory.GetFiles(a).ToList();

            List<string> photos = getFiles.Select(f =>
                f.Replace(_hostingEnvironment.WebRootPath, "")
            ).ToList();

            ViewBag.UserName = "" + HttpContext.Session.GetString("UserName");
			return View(photos);
        }


        public IActionResult Upload(IFormFile[] file)
        {
            return Json("OK");
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
