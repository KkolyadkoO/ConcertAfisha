using AutoMapper;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;

namespace ConcertAfisha.Application.UseCases.Concert;

public class CreateConcertUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public CreateConcertUseCase(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<Guid> Execute(ConcertRequestDto receiverConcert, IFormFile imageFile)
    {
        var newConcert = _mapper.Map<Core.Models.Concert>(receiverConcert);
        if (imageFile != null)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var allowedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/webp" };

            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            var mimeType = imageFile.ContentType;

            if (!allowedExtensions.Contains(fileExtension) || !allowedMimeTypes.Contains(mimeType))
            {
                throw new InvalidOperationException("The uploaded file is not a valid image.");
            }

            newConcert.ImageUrl = await _imageService.SaveImageToFileSystem(imageFile);
        }

        var id = await _unitOfWork.Concerts.CreateAsync(newConcert);
        await _unitOfWork.Complete();
        return id;
    }
}