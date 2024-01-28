using Microsoft.AspNetCore.Mvc;
using TestSheetScanner.Services;

namespace TestSheetScanner.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // Example action for processing an uploaded image
        [HttpPost]
        public IActionResult ProcessImage(IFormFile file)
        {
            _imageService.ProcessImage(file);
            return Ok();
        }
        [HttpPost]
        public IActionResult CaptureImage(IFormFile file)
        {
            _imageService.ProcessImage(file);
         
            return Json(new { status = "success" });
        }
        // Example action for executing a Python script
        [HttpPost]
        public IActionResult ExecutePythonScript(string scriptPath)
        {
            _imageService.ExecutePythonScript(scriptPath);
            return Ok();
        }
    }
}