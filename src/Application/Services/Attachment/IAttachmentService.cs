using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IAttachmentService
    {
        Task<Result> Create(Attachment attachment, IFormFile file, CancellationToken cancellationToken = new());
    }
}