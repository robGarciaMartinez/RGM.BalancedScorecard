namespace RGM.BalancedScorecard.Domain.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Factories;
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorCommandHandler : ICommandHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        private readonly IDomainEntityFactory<IIndicator, CreateIndicatorCommand> factory;

        private readonly IIndicatorStateCalculator stateCalculator;

        public CreateIndicatorCommandHandler(
            IIndicatorsRepository repository,
            IDomainEntityFactory<IIndicator, CreateIndicatorCommand> factory,
            IIndicatorStateCalculator stateCalculator)
        {
            this.repository = repository;
            this.factory = factory;
            this.stateCalculator = stateCalculator;
        }

        public void Execute(CreateIndicatorCommand command)
        {
            var indicator = this.factory.Create(command);
            indicator.Create(this.stateCalculator);

            this.repository.Insert(indicator);
        }
    }
}
