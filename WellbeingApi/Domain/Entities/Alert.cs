using Domain.Enums;

namespace Domain.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Enums.Type Type { get; set; }
        public TimeOnly ExecutionTime { get; set; }
        public DaysOfExecution DaysOfExecution { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
    }
}
