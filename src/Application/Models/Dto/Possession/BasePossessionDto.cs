using Domain.Enums;

namespace Application.Models.Dto
{
    public class BasePossessionDto
    {
        public string title { get; set; }
        public string? description { get; set; }
        public int meter { get; set; }
        public string ConstructionDate { get; set; } //
        public long RegionId { get; set; }
        public PossessionType Type { get; set; }
        public TransactionType TransactionType { get; set; }
        public PossessionState State { get; set; }
    }

    public class PossessionDto
    {
        public BasePossessionDto Base { get; set; }
        public Dictionary<string, object> DynamicForm { get; set; }
    }
}
