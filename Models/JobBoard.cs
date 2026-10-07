namespace StackMatch.Models
{
    public class JobBoard
    {
        public List<JobListing> AppliedJobs { get; set; } = new List<JobListing>();
        public List<JobListing> Interviews { get; set; } = new List<JobListing>();
        public List<JobListing> Offers { get; set; } = new List<JobListing>();
        public List<JobListing> Rejections { get; set; } = new List<JobListing>();
    }
}
