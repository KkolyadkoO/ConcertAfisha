using AutoMapper;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;

namespace ConcertAfisha.Application.UseCases.Concert;

public class UpdateConcertUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;

    public UpdateConcertUseCase(IUnitOfWork unitOfWork, IImageService imageService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _mapper = mapper;
    }
    
    public async Task Execute(Guid id, ConcertRequestDto request, IFormFile? imageFile)
    {
        var existingConcert = await _unitOfWork.Concerts.GetByIdAsync(id);
        if (existingConcert == null)
        {
            throw new NotFoundException("Concert not found");
        }

        var updatedEvent = _mapper.Map<Core.Models.Concert>(request);

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

            updatedEvent.ImageUrl = await _imageService.UpdateImageToFileSystem(imageFile, existingConcert.ImageUrl);
        }
        updatedEvent.Id = id;

        await _unitOfWork.Concerts.UpdateAsync(updatedEvent);
        await _unitOfWork.Complete();
    }
}