using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class UpdateIndicatorCommandHandler : BaseCommandHandler<UpdateIndicatorCommand>
    {
        private readonly IAggregateRootRepository<Indicator> _repository;

        public UpdateIndicatorCommandHandler(IValidator<UpdateIndicatorCommand> validator, IAggregateRootRepository<Indicator> repository)
            : base(validator)
        {
            _repository = repository;
        }

        public override async Task OnSuccessfulValidation(UpdateIndicatorCommand command)
        {
            var indicator = await _repository.GetAggregateRootAsync(command.Id);
            indicator.Update(
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

            await _repository.UpdateAsync(indicator, command.RequestedBy);
        }
    }
}
