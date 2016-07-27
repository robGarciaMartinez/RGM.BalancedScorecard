namespace RGM.BalancedScorecard.Domain.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class DeleteIndicatorCommandHandler : ICommandHandler<DeleteIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public DeleteIndicatorCommandHandler(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public void Execute(DeleteIndicatorCommand command)
        {
            this.repository.Delete(command.Id);
        }
    }
}
