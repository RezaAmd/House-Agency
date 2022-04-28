using Domain.Enums;

namespace WebApi.Areas.Manage.Models
{
    #region Form
    public class CreateFormMDAO
    {
        public string Name { get; set; }
        public FormType Type { get; set; }
    }
    #endregion

    #region Control
    public class CreateControlMDAO
    {
        public string Name { get; set; }
    }
    #endregion
}
