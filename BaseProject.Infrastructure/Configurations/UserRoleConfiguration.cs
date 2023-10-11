using BaseProject.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("userRole")
                .HasKey(x => x.UserRoleId);

            builder.Property(p => p.UserRoleId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.RoleId)
                .IsRequired();
        }
    }
}