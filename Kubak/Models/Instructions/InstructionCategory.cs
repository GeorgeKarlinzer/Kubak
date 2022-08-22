namespace Kubak.Models
{
    public class InstructionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public InstructionCategory Category { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public ICollection<InstructionCategory> ChildCategories { get; set; }
        public ICollection<Instruction> Instructions { get; set; }

        public InstructionCategory()
        {
            ChildCategories = new List<InstructionCategory>();
            Instructions = new List<Instruction>();
        }
    }
}
