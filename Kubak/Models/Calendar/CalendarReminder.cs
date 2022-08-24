namespace Kubak.Models
{
    public class CalendarReminder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan RepeatInterval { get; set; }
        public string CreatorId { get; set; }
        public string ExecutorId { get; set; }

        public User Creator { get; set; }
        public User Execututor { get; set; }
    }
}
