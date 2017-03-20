using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using System.Collections.Generic;

namespace RGM.BalancedScorecard.Kernel.IoC
{
    public interface IDependencyContainer
    {
        IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() 
            where TCommand : ICommand;

        IEnumerable<ISpecification<TAggregateRoot, TCommand>> GetSpecifications<TAggregateRoot, TCommand>() 
            where TAggregateRoot : AggregateRoot
            where TCommand : ICommand;
    }
}
