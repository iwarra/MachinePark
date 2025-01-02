namespace MachinePark.Shared.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
