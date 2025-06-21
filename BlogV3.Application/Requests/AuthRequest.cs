using BlogV3.Application.Queries.Auth.Login;

namespace BlogV3.Application.Requests
{
    public class AuthRequest
    {
        #region Properties

        public string? Email { get; set; } = default!;
        public string? FullName { get; set; } = default!;
        public string? Password { get; set; } = default!;
        public string? Username { get; set; } = default!;
        public string? Token { get; set; } = default!;
        public DateTime? ExpiresAt { get; set; }

        #endregion Properties

        #region Public Methods

        public LoginQuery LoginQuery() => new(Email, Username, Password);

        #endregion Public Methods
    }
}