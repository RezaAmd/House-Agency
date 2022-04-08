namespace Domain.Entities.Identity
{
    public class Role : BaseEntity
    {
        #region Constructors
        Role() { }
        public Role(string name, string? title, string? description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name.Trim();
            NormalizedName = name.Trim().ToUpper();
            Title = title.Trim();
            Description = description.Trim();
        }
        #endregion

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
#nullable enable
        public string? Title { get; set; }
        public string? Description { get; set; }
#nullable disable

        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}