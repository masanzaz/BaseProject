
namespace BaseProject.Domain.Entities.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DateCreatedUtc { get; set; }
        public string? ModifiedBy { get; set; } = string.Empty;
        public DateTime? DateModifiedUtc { get; set; }
    }
}