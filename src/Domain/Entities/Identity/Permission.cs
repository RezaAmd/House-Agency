namespace Domain.Entities.Identity
{
    public class Permission : BaseEntity
    {
        #region Ctor
        Permission() { }

        public Permission(string name, string title = null, string description = null)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Title = title;
            Description = description;
        }
        #endregion

        public string Id { get; set; }
        public string Name { get; set; } // Unique name.
#nullable enable
        public string? Title { get; set; }
        public string? Description { get; set; }
#nullable disable

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
