using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum PossessionType
    {
        [Display(Name = "مسکونی")]
        Residential,
        [Display(Name = "اداری تجاری")]
        CommercialOffice
    }
}