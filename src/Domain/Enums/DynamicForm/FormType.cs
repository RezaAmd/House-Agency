using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum FormType
{
    [Display(Name = "ساده")]
    Normal,
    [Display(Name = "گروه")]
    FormGroup
}