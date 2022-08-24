using Microsoft.AspNetCore.Identity;

namespace Kubak.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Instruction> Instructions { get; set; }
        public ICollection<InstructionCategory> InstructionCategories { get; set; }
        public ICollection<UserOrganization> UserOrganizations { get; set; }

        public Organization()
        {
            Instructions = new List<Instruction>();
            InstructionCategories = new List<InstructionCategory>();
        }
    }
}
