using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Kernel.Domain.Commands
{
    public interface ICommandBus
    {
        Task SubmitAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
