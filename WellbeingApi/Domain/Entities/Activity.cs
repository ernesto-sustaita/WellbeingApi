using Domain.Enums;

namespace Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Enums.Type Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Duration { get; set; }
    }
}
