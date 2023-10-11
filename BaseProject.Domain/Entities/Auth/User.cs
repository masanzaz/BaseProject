using BaseProject.Domain.Entities.Common;

namespace BaseProject.Domain.Entities.Auth
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateLastLoggedInUtc { get; set; }

        public bool Enabled { get; set; }
        public virtual List<UserRole>? UserRoles { get; set; }
    }
}