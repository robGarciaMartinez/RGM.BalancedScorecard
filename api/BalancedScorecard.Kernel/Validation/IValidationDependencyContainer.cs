using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Validation;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Validation
{
    public interface IValidationDependencyContainer
    {
        IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() 
            where TCommand : ICommand;

        IEnumerable<ISpecification<TAggregateRoot, TCommand>> GetSpecifications<TAggregateRoot, TCommand>() 
            where TAggregateRoot : IAggregateRoot
            where TCommand : ICommand;
    }
}
