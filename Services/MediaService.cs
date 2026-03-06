using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class MediaService
{
    private readonly IWebHostEnvironment _env;

    public MediaService(IWebHostEnvironment env) => _env = env;

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}.webp";
        var path = Path.Combine(_env.WebRootPath, "uploads", fileName);

        using var image = await Image.LoadAsync(file.OpenReadStream());
        // Resmi otomatik boyutlandır ve WebP yap
        image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(1080, 1350), Mode = ResizeMode.Max }));
        await image.SaveAsWebpAsync(path);

        return $"/uploads/{fileName}";
    }

    public async Task<string> UploadVideoAsync(IFormFile file)
    {
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var path = Path.Combine(_env.WebRootPath, "uploads", fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return $"/uploads/{fileName}";
    }
}