namespace Domain.Entities.Identity
{
    public class Role : BaseEntity
    {
        #region Constructors
        Role() { }
        public Role(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name.Trim();
            NormalizedName = name.Trim().ToUpper();
        }
        #endregion

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        #region Relations
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}