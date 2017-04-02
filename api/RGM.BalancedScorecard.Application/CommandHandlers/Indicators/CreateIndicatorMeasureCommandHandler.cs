using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class CreateIndicatorMeasureCommandHandler : ICommandHandler<CreateIndicatorMeasureCommand>
    {
        private readonly IAggregateRootRepository<Indicator> _repository;
        private readonly IIndicatorStateCalculator _stateCalculator;

        public CreateIndicatorMeasureCommandHandler(IAggregateRootRepository<Indicator> repository, IIndicatorStateCalculator stateCalculator)
        {
            _repository = repository;
            _stateCalculator = stateCalculator;
        }

        public async Task ExecuteAsync(CreateIndicatorMeasureCommand command)
        {
            var indicator = await _repository.GetAggregateRootAsync(command.IndicatorId);
            indicator.AddMeasure(new IndicatorMeasure(command.Date, command.Record, command.Objective, command.Notes));
            indicator.SetState(_stateCalculator.Calculate(indicator));

            await _repository.UpdateAsync(indicator, command.RequestedBy);
        }
    }
}
