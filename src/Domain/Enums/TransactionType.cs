using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum TransactionType
{
    [Display(Name = "خرید/فروش")]
    Buy,
    [Display(Name = "رهن/اجاره")]
    Rent
}