namespace BaseProject.Domain.Entities
{
    public class SeedingEntry
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreatedUtc { get; set; } = DateTime.UtcNow;
    }
}