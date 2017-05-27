using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Domain.Events.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Events;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using System;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class CreateIndicatorCommandHandler : BaseCommandHandler<CreateIndicatorCommand>
    {
        private readonly IAggregateRootRepository<Indicator> _repository;
        private readonly IIndicatorStateCalculator _stateCalculator;
        private readonly IEventBus _eventBus;

        public CreateIndicatorCommandHandler(
            IValidator<CreateIndicatorCommand> validator, 
            IAggregateRootRepository<Indicator> repository,
            IIndicatorStateCalculator stateCalculator,
            IEventBus eventBus) : base(validator)
        {
            _repository = repository;
            _stateCalculator = stateCalculator;
            _eventBus = eventBus;
        }

        public override async Task OnSuccessfulValidation(CreateIndicatorCommand command)
        {
            var indicator = new Indicator(
                command.Name,
                command.Description,
                command.StartDate,
                command.Code,
                command.Unit,
                command.Periodicity,
                command.ComparisonValue,
                command.ObjectValue,
                command.IndicatorTypeId,
                command.ResponsibleId,
                command.FulfillmentRate,
                command.Cumulative);

            indicator.SetState(_stateCalculator.Calculate(indicator));
            indicator.SetId(Guid.NewGuid());

            await _repository.InsertAsync(indicator, command.RequestedBy);
            await _eventBus.SubmitAsync(new IndicatorCreatedEvent { IndicatorId = indicator.Id });
        }
    }
}
