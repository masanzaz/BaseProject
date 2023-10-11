using BaseProject.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role")
                .HasKey(x => x.RoleId);

            builder.Property(p => p.RoleId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(t => t.Enabled)
                .IsRequired();
        }
    }
}