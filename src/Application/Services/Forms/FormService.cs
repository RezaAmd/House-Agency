using Application.Extensions;
using Application.Models;
using Application.Models.ViewModels;
using Application.Repositories.Controls;
using Application.Repositories.Forms;
using Mapster;

namespace Application.Services.Forms;

public class FormService : IFormService
{
    #region Dependency Injection
    private readonly IFormRepositoy _formRepository;
    private readonly IControlRepository _controlRepository;

    public FormService(IFormRepositoy formRepository,
        IControlRepository controlRepository)
    {
        _formRepository = formRepository;
        _controlRepository = controlRepository;
    }
    #endregion

    public async Task<PaginatedList<TinyFormVM>> GetAllFormsName(string keyword, int page = 1, int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var forms = _formRepository.Table.AsQueryable();
        if (keyword != null)
        {

        }
        return await forms
            .ProjectToType<TinyFormVM>()
            .PaginatedListAsync(page, pageSize, cancellationToken);
    }

}