using BalancedScorecard.Kernel.Commands;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class BaseCommand : ICommand
    {
        public string RequestedBy { get; set; }
    }
}
