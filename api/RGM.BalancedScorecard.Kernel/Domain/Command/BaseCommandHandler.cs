using RGM.BalancedScorecard.Kernel.Domain.Model;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Kernel.Domain.Commands
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> 
        where TCommand : ICommand
    {
        protected readonly IValidator<TCommand> _validator;

        public BaseCommandHandler(IValidator<TCommand> validator)
        {
            _validator = validator;
        }

        public Task ExecuteAsync(TCommand command)
        {
            _validator.Validate(command);
            return OnSuccessfulValidation(command);
        }

        public abstract Task OnSuccessfulValidation(TCommand command);
    }

    public abstract class BaseCommandHandler<TAggregateRoot, TCommand> : ICommandHandler<TCommand>
        where TAggregateRoot : AggregateRoot
        where TCommand : ICommand
    {
        protected readonly IValidator<TAggregateRoot, TCommand> _validator;

        public BaseCommandHandler(IValidator<TAggregateRoot, TCommand> validator)
        {
            _validator = validator;
        }

        public Task ExecuteAsync(TCommand command)
        {
            var aggregateRoot = GetAggregateRoot(command);
            _validator.Validate(aggregateRoot, command);
            return OnSuccessfulValidation(aggregateRoot, command);
        }

        public abstract TAggregateRoot GetAggregateRoot(TCommand command);

        public abstract Task OnSuccessfulValidation(TAggregateRoot aggregateRoot, TCommand command);
    }
}