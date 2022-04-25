using Domain.Enums;

namespace WebApi.Areas.Manage.Models
{
    public class RegionMVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public RegionType Type { get; set; }
    }

    public class CreateRegionMVM
    {
        public CreateRegionMVM(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
