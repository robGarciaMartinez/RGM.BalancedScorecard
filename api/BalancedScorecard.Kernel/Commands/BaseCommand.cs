namespace BalancedScorecard.Kernel.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public string RequestedBy { get; set; }
    }
}
