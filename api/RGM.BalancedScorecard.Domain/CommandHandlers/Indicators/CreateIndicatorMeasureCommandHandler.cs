namespace RGM.BalancedScorecard.Domain.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorMeasureCommandHandler : ICommandHandler<CreateIndicatorMeasureCommand>
    {
        private readonly IIndicatorsRepository repository;

        public CreateIndicatorMeasureCommandHandler(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public CommandHandlerResponse Execute(CreateIndicatorMeasureCommand command)
        {
            var indicator = this.repository.FindByKey(command.IndicatorId);

            return new CommandHandlerResponse();
        }
    }
}
