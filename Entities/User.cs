using Microsoft.AspNetCore.Identity;

namespace StackMatch.Entities
{
    public class User : IdentityUser
    {
        public int UserId { get; set; } = default;
        public string? FirstName { get; set; } = default;
        public string? LastName { get; set; } = default;
        public string? Username { get; set; } = default;
        public string? Password { get; set; } = default;
        public string? EmailAddress { get; set; } = default;
    }
}
