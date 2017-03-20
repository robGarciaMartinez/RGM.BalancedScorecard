using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using RGM.BalancedScorecard.Kernel.IoC;
using System;
using System.Collections.Generic;

namespace RGM.BalancedScorecard.Kernel.Domain.Validation
{
    public class BaseValidator<TCommand> : IValidator<TCommand>
        where TCommand : ICommand
    {
        protected readonly IDependencyContainer _container;
 
        public BaseValidator(IDependencyContainer container)
        {
            _container = container;
        }

        public void Validate(TCommand command)
        {
            foreach (var specification in GetSpecifications<TCommand>())
            {
                if (!specification.IsSatisfiedBy(command))
                {
                    throw new ArgumentException(specification.ErrorMessage);
                }
            }
        }

        protected virtual IEnumerable<ISpecification<TC>> GetSpecifications<TC>() 
            where TC : ICommand
        {
            return _container.GetSpecifications<TC>();
        }
    }

    public class BaseValidator<TAggregateRoot, TCommand> : BaseValidator<TCommand>, IValidator<TAggregateRoot, TCommand>
        where TAggregateRoot : AggregateRoot
        where TCommand : ICommand
    {
        public BaseValidator(IDependencyContainer container) : base(container)
        {
        }

        public void Validate(TAggregateRoot aggregateRoot, TCommand command)
        {
            Validate(command);
            foreach (var specification in GetSpecifications<TAggregateRoot, TCommand>())
            {
                if (!specification.IsSatisfiedBy(aggregateRoot, command))
                {
                    throw new ArgumentException(specification.ErrorMessage);
                }
            }
        }

        protected virtual IEnumerable<ISpecification<TA, TC>> GetSpecifications<TA, TC>()
            where TA : AggregateRoot
            where TC : ICommand
        {
            return _container.GetSpecifications<TA, TC>();
        }
    }
}
