using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Model;

namespace RGM.BalancedScorecard.Kernel.Domain.Validation
{
    public interface IValidator<in TCommand>
        where TCommand : ICommand
    {
        void Validate(TCommand command);
    }

    public interface IValidator<in TAggregateRoot, in TCommand>
        where TAggregateRoot : AggregateRoot
        where TCommand : ICommand
    {
        void Validate(TAggregateRoot aggregateRoot, TCommand command);
    }
}
