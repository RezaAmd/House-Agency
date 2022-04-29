using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.FluentApi
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> b)
        {
            b.ToTable("Forms");

            b.HasIndex(e => e.Name)
                .IsUnique();

            b.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            b.Property(e => e.Title)
                .HasMaxLength(30);

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.FormControls)
                .WithOne(e => e.Form);
        }
    }
}