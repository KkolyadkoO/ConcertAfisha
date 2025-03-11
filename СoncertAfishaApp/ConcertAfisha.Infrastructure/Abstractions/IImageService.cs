using Microsoft.AspNetCore.Http;

namespace ConcertAfisha.Infrastructure.Abstractions;

public interface IImageService
{
    public Task<string> SaveImageToFileSystem(IFormFile imageFile);
    public Task<string> UpdateImageToFileSystem(IFormFile imageFile, string oldImageUrl);
}