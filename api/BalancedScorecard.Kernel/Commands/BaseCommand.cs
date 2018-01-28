namespace BalancedScorecard.Kernel.Commands
{
    public class BaseCommand : ICommand
    {
        public string RequestedBy { get; set; }
    }
}
