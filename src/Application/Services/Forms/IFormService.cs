using Application.Models;
using Application.Models.ViewModels;

namespace Application.Services.Forms;

public interface IFormService
{
    Task<PaginatedList<TinyFormVM>> GetAllFormsName(string keyword, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default);
}