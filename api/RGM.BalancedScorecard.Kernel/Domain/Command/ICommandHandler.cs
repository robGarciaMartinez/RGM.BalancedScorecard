using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Kernel.Domain.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}
