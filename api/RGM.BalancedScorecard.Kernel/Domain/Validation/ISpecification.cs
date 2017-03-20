using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Model;

namespace RGM.BalancedScorecard.Kernel.Domain.Validation
{
    public interface ISpecification
    {
        string ErrorMessage { get; }
    }

    public interface ISpecification<in TCommand> : ISpecification 
        where TCommand : ICommand
    {
        bool IsSatisfiedBy(TCommand command);
    }

    public interface ISpecification<in TAggregateRoot, in TCommand> : ISpecification 
        where TAggregateRoot : AggregateRoot
        where TCommand : ICommand
    {
        bool IsSatisfiedBy(TAggregateRoot aggregateRoot, TCommand command);
    }
}
