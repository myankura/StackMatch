namespace StackMatch.Models
{
    public class JobListing
    {
        public int Id { get; set; } = default;
        public string? Company { get; set; } = default;
        public string? Title { get; set; } = default;
        public string? Location { get; set; } = default;
        public double MinSalary { get; set; } = default;
        public double MaxSalary { get; set; } = default;
        public double ExpectedSalary { get; set; } = default;
        public Benefits BenefitsPackage { get; set; } = new Benefits();
        public DateTimeOffset DatePosted { get; set; } = default;
        public DateTimeOffset DateApplied { get; set; } = default;
        public string? ReqCode { get; set; } = default;
        public bool Rejected { get; set; } = default;
        public string? JobBoard { get; set; } = default;
        public string? JobBoardURL { get; set; } = default;
        public string? CompanyWebsite { get; set; } = default;
        public string? Notes { get; set; } = default;
    }
}
