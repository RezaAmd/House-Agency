using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class PaginationParameter
    {
        [Range(1, 1000, ErrorMessage = "حداقل شماره صفحه 1 و حداکثر 1000 می باشد.")]
        public int Page { get; set; } = 1;
    }
}