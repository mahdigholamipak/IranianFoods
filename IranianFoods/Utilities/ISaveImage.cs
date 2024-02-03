namespace IranianFoods.Utilities
{
    public interface ISaveImage
    {
        string path { get; }
        Task<bool> UploadFile(IFormFile file);
    }
}
