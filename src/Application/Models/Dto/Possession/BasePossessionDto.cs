﻿using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dto
{
    public class BasePossessionDto
    {
        [Required(ErrorMessage = "محدوده آگهی را مشخص کنید.")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "متراژ سازه در آگهی ضروری است.")]
        public int meter { get; set; }
        #region prices
        public ulong Price { get; set; }
        public ulong Rent { get; set; }
        public ulong Mortgage { get; set; }
        #endregion
        public string? ConstructionDate { get; set; } // YYYY
        public PossessionType Type { get; set; }
        public TransactionType TransactionType { get; set; }
        public bool IsDraft { get; set; }
        [Required(ErrorMessage = "عنوان آگهی ضروری است.")]
        public string title { get; set; }
        public string? description { get; set; }
    }

    public class PossessionDto
    {
        public BasePossessionDto Base { get; set; }
        public Dictionary<string, object> DynamicForm { get; set; }
    }
}
