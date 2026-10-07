namespace StackMatch.Models
{
    public class User
    {
        public int UserId { get; set; } = default;
        public string? FirstName { get; set; } = default;
        public string? LastName { get; set; } = default;
        public string? Username { get; set; } = default;
        public string? Password { get; set; } = default;
        public string? EmailAddress { get; set; } = default;
    }
}
