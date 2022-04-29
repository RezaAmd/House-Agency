using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.FluentApi
{
    public class ControlConfiguration : IEntityTypeConfiguration<Control>
    {
        public void Configure(EntityTypeBuilder<Control> b)
        {
            b.ToTable("Controls");

            b.HasIndex(e => e.Name)
                .IsUnique();

            b.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            b.Property(e => e.Label)
                .HasMaxLength(30);

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.FormControls)
                .WithOne(e => e.Form);
        }
    }
}