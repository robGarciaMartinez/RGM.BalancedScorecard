namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    using Domain.Commands.Indicators;
    using Domain.Model.Indicators;
    using Domain.Repositories;
    using Domain.Services.Interfaces;
    using SharedKernel.Domain.Commands;

    public class CreateIndicatorMeasureCommandHandler : ICommandHandler<CreateIndicatorMeasureCommand>
    {
        private readonly IIndicatorsRepository repository;

        private readonly IIndicatorStateCalculator stateCalculator;

        public CreateIndicatorMeasureCommandHandler(IIndicatorsRepository repository, IIndicatorStateCalculator stateCalculator)
        {
            this.repository = repository;
            this.stateCalculator = stateCalculator;
        }

        public void Execute(CreateIndicatorMeasureCommand command)
        {
            var indicator = this.repository.FindByKey(command.IndicatorId);
            indicator.AddMeasure(new IndicatorMeasure(command.Date, command.Record, command.Objective, command.Notes, command.Id));
            indicator.SetState(this.stateCalculator.Calculate(indicator));

            this.repository.Update(indicator);
        }
    }
}
