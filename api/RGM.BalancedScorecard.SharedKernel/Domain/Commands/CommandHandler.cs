namespace RGM.BalancedScorecard.SharedKernel.Domain.Commands
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly IValidator<TCommand> validator;

        protected CommandHandler(IValidator<TCommand> validator)
        {
            this.validator = validator;
        }

        public void Execute(TCommand command)
        {
            var validationResult = this.validator.Validate(command);
            if (validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(",", validationResult.ValidationMessages));
            }
        }

        public abstract void OnSuccessValidation(TCommand command);
    }
}
