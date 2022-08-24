namespace Kubak.Models
{
    public class CalendarTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? EventId { get; set; }
        public DateTime? Deadline { get; set; }
        public string CreatorId { get; set; }
        public string ExecutorId { get; set; }
        public bool IsDone { get; set; }

        public User Creator { get; set; }
        public User Execututor { get; set; }
    }
}
