
using IranianFoods.Models.ViewModels;
using System.IO;
using static NuGet.Packaging.PackagingConstants;

namespace IranianFoods.Utilities
{
    public class SaveImage : ISaveImage
    {
        private IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _iConfig;
        private string _directory;
        public string path { get; private set; }
        public SaveImage(IWebHostEnvironment webHostEnvironment, IConfiguration iConfig)
        {
            _webHostEnvironment = webHostEnvironment;
            _iConfig = iConfig;
        }

        private void setDirectory()
        {
            string? ImagesFolderName = _iConfig.GetValue<string>("ImagesDirectory:FromRoot");
            _directory = Path.Combine(_webHostEnvironment.WebRootPath, ImagesFolderName);
        }


        private void createDirectory()
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
        }

        private async Task saveFile(IFormFile file)
        {
            path = Path.Combine(_directory, $@"{DateTime.Now.Ticks}{file.FileName}");
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            var fileName = Path.GetFileName(path);
            string? ImagesFolderName = _iConfig.GetValue<string>("ImagesDirectory:FromRoot");
            path = $@"{ImagesFolderName}/{fileName}";
        }

        public async Task<bool> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                setDirectory();
                createDirectory();
                await saveFile(file);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
