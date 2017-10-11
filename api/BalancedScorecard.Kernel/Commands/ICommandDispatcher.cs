using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public interface ICommandDispatcher
    {
        Task Submit<TCommand>(TCommand command) where TCommand : ICommand; 
    }
}
