using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}
