using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestSheetScanner.Models;

namespace TestSheetScanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Capture()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessImage(string imageData)
        {
            // Process the captured image data
            // You can save it to a file, send it to a server, etc.

            // Example: save the image to a file named "capturedImage.jpg"
            byte[] imageBytes = Convert.FromBase64String(imageData);

            string filePath = "capturedImage.jpg";
            System.IO.File.WriteAllBytes(filePath, imageBytes);

            return Json(new { success = true });
        }
    }
}
