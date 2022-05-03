using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Possession
{
    public class BasePossessionDto
    {
        public string title { get; set; }
        public string? description { get; set; }
        public int meter { get; set; }
        public DateTime? ConstructionDateTime { get; set; } //
        public PossessionType Type { get; set; }
        public TransactionType TransactionType { get; set; }
        public PossessionState State { get; set; }
    }

    public class PossessionDto
    {
        public BasePossessionDto Base { get; set; }
        public Dictionary<string,object> DynamicForm { get; set; }
    }
}
