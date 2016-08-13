namespace RGM.BalancedScorecard.Domain.CommandHandlers
{
    using SharedKernel.DependencyContainer;
    using SharedKernel.Domain.Commands;

    public class CommandBus : ICommandBus
    {
        private readonly IDependencyContainer dependencyContainer;

        public CommandBus(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public CommandHandlerResponse Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandValidator = this.dependencyContainer.GetValidator<TCommand>();
            var validationResult = commandValidator.Validate(command);

            return !validationResult.IsValid
                       ? new CommandHandlerResponse(validationResult.ValidationMessages)
                       : this.dependencyContainer.GetCommandHandler<TCommand>().Execute(command);
        }
    }
}
