namespace WebApi.Areas.Manage.Models
{
    public class RoleThumbailMVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateRoleMVM
    {
        public CreateRoleMVM(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}