namespace BaseProject.Domain.Models.Users
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public DateTime DateLastLoggedInUtc { get; set; }

        public bool Enabled { get; set; }

    }
}
