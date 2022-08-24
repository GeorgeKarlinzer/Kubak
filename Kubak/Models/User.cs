using Microsoft.AspNetCore.Identity;

namespace Kubak.Models
{
    public class User : IdentityUser<string>
    {
        public ICollection<UserOrganization> Organizations { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
    }
}
