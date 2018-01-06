using BalancedScorecard.Kernel.Commands;

namespace BalancedScorecard.Domain.Commands
{
    public class BaseCommand : ICommand
    {
        public string RequestedBy { get; set; }
    }
}
