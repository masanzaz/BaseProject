using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BaseProject.Domain.Entities.Auth;

namespace BaseProject.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user")
                .HasKey(x => x.UserId);

            builder.Property(p => p.UserId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(t => t.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.EmailAddress)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(u => u.EmailAddress)
                .IsUnique();

            builder.Property(t => t.Enabled)
                .IsRequired();

            builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
        }
    }
}