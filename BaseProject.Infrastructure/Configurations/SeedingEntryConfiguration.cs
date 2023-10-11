using BaseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Configurations
{
    class SeedingEntryConfiguration : IEntityTypeConfiguration<SeedingEntry>
    {
        public void Configure(EntityTypeBuilder<SeedingEntry> builder)
        {
            builder.ToTable("__SeedingHistory");
            builder.HasKey(s => s.Name);

            builder.Property(t => t.Name)
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(t => t.DateCreatedUtc)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        }
    }
}