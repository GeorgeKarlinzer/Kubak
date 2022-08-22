using Kubak.Models;

namespace Kubak.ViewModels
{
    public class InstructionsViewModel
    {
        public IEnumerable<Instruction> Instructions { get; set; }
        public IEnumerable<InstructionCategory> Categories { get; set; }
    }
}
