namespace Kubak.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? CategoryId { get; set; }
        public int OrganizationId { get; set; }

        public InstructionCategory Category { get; set; }
        public Organization Organization { get; set; }
    }
}
