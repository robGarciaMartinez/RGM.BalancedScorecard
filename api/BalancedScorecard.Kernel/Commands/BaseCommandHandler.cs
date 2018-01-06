using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using BalancedScorecard.Kernel.Validation;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Commands
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> 
        where TCommand : ICommand
    {
        protected readonly IValidator<TCommand> _validator;

        public BaseCommandHandler(IValidator<TCommand> validator)
        {
            _validator = validator;
        }

        public async Task Execute(TCommand command)
        {
            Guard.AgainstArgumentNullException(command, nameof(command));

            var validationResult = await _validator.Validate(command);
            if (validationResult.IsValid)
            {
                await OnSuccessfulValidation(command);
            }
            else
            {
                await OnUnsuccessfulValidation(command, validationResult);
            }
        }

        protected virtual Task OnUnsuccessfulValidation(TCommand command, ValidationResult validationResult)
        {
            throw new ValidationException(validationResult.Errors);
        }

        protected abstract Task OnSuccessfulValidation(TCommand command);
    }

    public abstract class BaseCommandHandler<TAggregateRoot, TCommand> : ICommandHandler<TCommand>
        where TAggregateRoot : IAggregateRoot
        where TCommand : ICommand
    {
        protected readonly IValidator<TAggregateRoot, TCommand> _validator;

        public BaseCommandHandler(IValidator<TAggregateRoot, TCommand> validator)
        {
            _validator = validator;
        }

        public async Task Execute(TCommand command)
        {
            Guard.AgainstArgumentNullException(command, nameof(command));

            var aggregateRoot = GetAggregateRoot(command);
            var validationResult = await _validator.Validate(aggregateRoot, command);
            if (validationResult.IsValid)
            {
                await OnSuccessfulValidation(aggregateRoot, command);
            }
            else
            {
                await OnUnsuccessfulValidation(command, aggregateRoot, validationResult);
            }
        }

        protected virtual Task OnUnsuccessfulValidation(TCommand command, TAggregateRoot aggregateRoot, ValidationResult validationResult)
        {
            throw new ValidationException(validationResult.Errors);
        }

        protected abstract TAggregateRoot GetAggregateRoot(TCommand command);

        protected abstract Task OnSuccessfulValidation(TAggregateRoot aggregateRoot, TCommand command);
    }
}
