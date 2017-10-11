using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Validation
{
    public interface IValidator<in TCommand>
        where TCommand : ICommand
    {
        Task<ValidationResult> Validate(TCommand command);
    }

    public interface IValidator<in TAggregateRoot, in TCommand>
        where TAggregateRoot : IAggregateRoot
        where TCommand : ICommand
    {
        Task<ValidationResult> Validate(TAggregateRoot aggregateRoot, TCommand command);
    }
}
