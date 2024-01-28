using Microsoft.AspNetCore.Http;

namespace TestSheetScanner.Services
{
    public interface IImageService
    {
        void ProcessImage(IFormFile file);
        void ExecutePythonScript(string scriptPath);
    }
}