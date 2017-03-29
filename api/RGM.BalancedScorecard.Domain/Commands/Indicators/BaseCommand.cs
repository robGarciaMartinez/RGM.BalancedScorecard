using RGM.BalancedScorecard.Kernel.Domain.Commands;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class BaseCommand : ICommand
    {
        public string RequestedBy { get; set; }
    }
}
