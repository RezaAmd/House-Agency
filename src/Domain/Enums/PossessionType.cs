using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum PossessionType
    {
        [Display(Name = "مسکونی")]
        Residential = 1,
        [Display(Name = "اداری تجاری")]
        CommercialOffice = 2
    }
}