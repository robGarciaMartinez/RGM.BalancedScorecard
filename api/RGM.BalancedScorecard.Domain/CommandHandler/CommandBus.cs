namespace RGM.BalancedScorecard.Domain.CommandHandler
{
    using RGM.BalancedScorecard.Domain.Dependencies;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CommandBus : ICommandBus
    {
        private readonly IDomainDependencyService service;

        public CommandBus(IDomainDependencyService service)
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
