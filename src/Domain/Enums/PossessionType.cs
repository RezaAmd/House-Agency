using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum PossessionType
{
    [Display(Name = "ویلایی/باغ و باغچه")]
    Vila_Garden,
    [Display(Name = "آپارتمان/برج")]
    Apartment_Tower,
    [Display(Name = "مستغلات")]
    RealEstate,
    [Display(Name = "زمین/کلنگی")]
    Land_OldHouse,
    [Display(Name = "پنت هاوس")]
    Penthouse,
    [Display(Name = "دفتر کار/اتاق اداری و مطب")]
    Office,
    [Display(Name = "انبار/سوله/کارگاه و کارخانه")]
    Warehouse_Factory_Workshop,
    [Display(Name = "کشاورزی")]
    Agriculture
}