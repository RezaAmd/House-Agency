using Application.Dao;
using Application.Extentions;
using Application.Models;
using Application.Models.ViewModels;
using Mapster;

namespace Application.Services
{
    public class FormService : IFormService
    {
        #region Dependency Injection
        private readonly IFormDao formDao;
        private readonly IControlDao controlDao;

        public FormService(IFormDao _formDao,
            IControlDao _controlDao)
        {
            formDao = _formDao;
            controlDao = _controlDao;
        }

        public async Task<PaginatedList<TinyFormVM>> GetAllFormsName(string keyword, int page = 1, int pageSize = 20,
            CancellationToken cancellationToken = default)
        {
            var forms = formDao.Table.AsQueryable();
            if (keyword != null)
            {

            }
            return await forms
                .ProjectToType<TinyFormVM>()
                .PaginatedListAsync(page, pageSize, cancellationToken);
        }
        #endregion


    }
}