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
        public string Label { get; set; }
        public FieldType Type { get; set; }
        public string? Placeholder { get; set; }
        public int Priority { get; set; }
        public string? JsonOption { get; set; }
        public bool IsRequired { get; set; }
    }
    #endregion
}
