namespace BaseProject.Application.Security
{
    public class AppSettings
    {
        public string Environment { get; set; } = string.Empty;

        public AuthenticationSettings Authentication { get; set; }
    }

    public class AuthenticationSettings
    {
        public string JwtIssuer { get; set; } = string.Empty;
        public string Jwtkey { get; set; } = string.Empty;
    }
}