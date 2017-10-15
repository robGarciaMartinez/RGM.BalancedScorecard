using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.CommandHandlers
{
    public class CreateIndicatorCommandHandler : ICommandHandler<CreateIndicatorCommand>
    {
        private readonly IRepository<Indicator> _repository;

        public CreateIndicatorCommandHandler(IRepository<Indicator> repository)
        {
            _repository = repository;
        }

        public async Task Execute(CreateIndicatorCommand command)
        {
            var indicator = await _repository.GetById(command.Id);
            if (indicator == null)
            {
                indicator = new Indicator(
                    command.Id,
                    command.Name,
                    command.Description,
                    command.Code,
                    command.Unit,
                    command.Periodicity,
                    command.ComparisonType,
                    command.IndicatorValueType,
                    command.IndicatorTypeId,
                    command.ResponsibleId,
                    command.FulfillmentRate,
                    command.Cumulative,
                    Domain.Enums.IndicatorEnum.Status.Green);
            }

            await  _repository.SaveAsync(indicator);
        }
    }
}
