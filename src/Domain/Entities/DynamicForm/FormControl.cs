using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class FormControl : BaseEntity
{
#nullable disable
    #region Constructors
    FormControl() { }
    public FormControl(string formId, string controlId, int priority = 0)
    {
        Id = Guid.NewGuid().ToString();
        Priority = priority;
        FormId = formId;
        ControlId = controlId;
    }
    #endregion

    public string Id { get; set; }
    public int Priority { get; set; } // order by this for priority.

    [ForeignKey("Form")]
    public string FormId { get; set; }
    public Form Form { get; set; }

    [ForeignKey("Control")]
    public string ControlId { get; set; }
    public Control Control { get; set; }
}