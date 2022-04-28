using Application.Dao;

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
        #endregion


    }
}