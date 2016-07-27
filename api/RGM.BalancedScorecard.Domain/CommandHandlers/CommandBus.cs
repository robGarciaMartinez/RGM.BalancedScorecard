namespace RGM.BalancedScorecard.Domain.CommandHandlers
{
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using RGM.BalancedScorecard.SharedKernel.Guard;

    public class CommandBus : ICommandBus
    {
        private readonly IDependencyContainer container;

        public CommandBus(IDependencyContainer container)
        {
            this.container = container;
        }

        public CommandResponse Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = this.container.GetCommandHandler<TCommand>();
            Guard.AgainstNullReference(handler, "Cannot find command hander");

            return handler.Execute(command);
        }
    }
}
