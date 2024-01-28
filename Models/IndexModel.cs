using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using TestSheetScanner.Services;

namespace TestSheetScanner.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IImageService _imageService;
        public IndexModel(IImageService imageService)
        {
            _imageService = imageService;
        }
        [BindProperty]
        public string FilePath { get; set; }

        [BindProperty]
        public IFormFile File { get; set; }

        public IActionResult OnGet()
        {
            return Redirect("/Index");
        }
        public IActionResult OnPost()
        {


            _imageService.ProcessImage(Request.Form.Files[0]);
            _imageService.ExecutePythonScript("main.py");
            var filePath = "uploads/" + File.FileName;
            using (var stream = System.IO.File.Create(filePath))
            {
                File.CopyTo(stream);
            }

            return RedirectToPage(); // Redirect back to the same page
        }

    }
}