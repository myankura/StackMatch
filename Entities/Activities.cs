namespace StackMatch.Entities
{
    public class Activities
    {
        public int Id { get; set; } = default;
        public string? Title { get; set; } = default;
        public int CategoryId { get; set; } = default;
        public DateTimeOffset StartDate { get; set; } = default;
        public DateTimeOffset EndDate { get; set; } = default;
        public string? Note { get; set; } = default;
        public bool Completed { get; set; } = default;
        public int UserId { get; set; } = default;
    }
}
