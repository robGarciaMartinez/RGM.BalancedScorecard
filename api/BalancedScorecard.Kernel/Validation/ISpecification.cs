using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Validation
{
    public interface ISpecification
    {
        string ErrorMessage { get; }
    }

    public interface ISyncSpecification<in TCommand> : ISpecification 
        where TCommand : ICommand
    {
        bool IsSatisfiedBy(TCommand command);
    }

    public interface ISpecification<in TCommand> : ISpecification 
        where TCommand : ICommand
    {
        Task<bool> IsSatisfiedBy(TCommand command);
    }

    public interface ISpecification<in TAggregateRoot, in TCommand> : ISpecification 
        where TAggregateRoot : IAggregateRoot
        where TCommand : ICommand
    {
        Task<bool> IsSatisfiedBy(TAggregateRoot aggregateRoot, TCommand command);
    }
}
