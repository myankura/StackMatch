namespace StackMatch.Entities
{
    public class Benefits
    {
        public bool Retirement401k { get; set; } = default;
        public double RetirementMatch { get; set; } = default;
        public bool Health { get; set; } = default;
        public bool HSA { get; set; } = default;
        public bool FSA { get; set; } = default;
        public bool Dental { get; set; } = default;
        public bool Vision { get; set; } = default;
        public bool PTO { get; set; } = default;
        public bool Life { get; set; } = default;
        public string? Other { get; set; } = default;
    }
}
