namespace WebApi.Areas.Manage.Models
{
    public class RoleThumbailMVM
    {
        public RoleThumbailMVM() { }
        public RoleThumbailMVM(string id, string name, string? title = null)
        {
            Id = id;
            Name = name;
            Title = title;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
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