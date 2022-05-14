using Application.Interfaces.Context;
using Application.Models;
using AspNetCore.FileServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        #region Dependency Injection
        private readonly IDbContext context;
        private readonly IFileService fileService;

        public AttachmentService(IDbContext _context, IFileService _fileService)
        {
            context = _context;
            fileService = _fileService;
        }
        #endregion

        public async Task<Attachment?> FindByIdAsync(string id, CancellationToken cancellationToken = new())
        {
            return await context.Attachments.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Result> CreateAsync(Attachment attachment, IFormFile file, CancellationToken cancellationToken = new())
        {
            await fileService.CopyToPathAsync(file, Path.Combine(Directory.GetCurrentDirectory(), attachment.Path), attachment.Name);
            attachment.Name += Path.GetExtension(file.FileName);
            await context.Attachments.AddAsync(attachment);
            if (Convert.ToBoolean(await context.SaveChangesAsync(cancellationToken)))
            {
                return Result.Success;
            }
            return Result.Failed();
        }

        public async Task<Result> DeleteAsync(Attachment attachment, CancellationToken cancellationToken = new())
        {
            bool deleteFileResult = await fileService
                .DeleteFromFullPathAsync(Path.Combine(Directory.GetCurrentDirectory(),
                attachment.Path + attachment.Name), cancellationToken);
            if (deleteFileResult)
            {
                context.Attachments.Remove(attachment);
                if (Convert.ToBoolean(await context.SaveChangesAsync(cancellationToken)))
                {
                    return Result.Success;
                }
                return Result.Failed(new List<Error>() { new Error(0, "پیوست مورد نظر حذف نشد.") });
            }
            return Result.Failed(new List<Error>() { new Error(1, "پیوست مورد نظر حذف نشد.") });
        }
    }
}