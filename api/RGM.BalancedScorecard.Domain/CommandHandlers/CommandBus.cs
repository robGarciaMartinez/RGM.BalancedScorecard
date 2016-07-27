namespace RGM.BalancedScorecard.Domain.CommandHandlers
{
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CommandBus : ICommandBus
    {
        private readonly IDependencyContainer service;

        public CommandBus(IDependencyContainer service)
        {
            this.service = service;
        }

        public void Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = this.service.GetCommandHandler<TCommand>();
            handler.Execute(command);
        }
    }
}
