using Application.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Attachments;

public interface IAttachmentService
{
    Task<Attachment?> FindByIdAsync(string id, CancellationToken cancellationToken = new());
    Task<List<Attachment>> FindByIdListAsync(List<string> idList, CancellationToken cancellationToken = new());
    Task<Result> CreateAsync(Attachment attachment, IFormFile file, CancellationToken cancellationToken = new());
    Task<Result> DeleteAsync(Attachment attachment, CancellationToken cancellationToken = new());
}