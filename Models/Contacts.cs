namespace StackMatch.Models
{
    public class Contacts
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string JobTitle { get; set; } = default!;
        public string Company { get; set; } = default!;
        public string Location { get; set; } = default!;
        public List<string> EmailAddresses { get; set; } = new List<string>();
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public List<string> SocialMedia { get; set; } = new List<string>();
    }
}
