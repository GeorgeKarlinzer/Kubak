using Microsoft.AspNetCore.Identity;

namespace Kubak.Models
{
    public class UserOrganization
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }
        public User User { get; set; }
    }
}
