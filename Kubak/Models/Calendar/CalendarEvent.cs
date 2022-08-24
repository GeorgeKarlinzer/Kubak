using Microsoft.AspNetCore.Identity;

namespace Kubak.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
