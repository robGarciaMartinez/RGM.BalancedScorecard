using System;
using System.Threading.Tasks;
using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;

namespace BalancedScorecard.Application.CommandHandlers
{
    public class UpdateIndicatorCommandHandler : ICommandHandler<UpdateIndicatorCommand>
    {
        private readonly IRepository<Indicator> _repository;

        public UpdateIndicatorCommandHandler(
            IRepository<Indicator> repository)
        {
            _repository = repository;
        }

        public async Task Execute(UpdateIndicatorCommand command)
        {
            if (command == null) throw new ArgumentNullException("Command can't be null");
            if (command.Id == null) throw new ArgumentException("Command Id can't be null");

            var indicator = await _repository.GetById(command.Id);
            if (indicator == null)
            {
                throw new ItemNotFoundException("Indicator not found");
            }

            indicator.Update(
                command.Name,
                command.Description,
                command.Code,
                command.Unit,
                command.PeriodicityType.Value,
                command.ComparisonType.Value,
                command.IndicatorValueType.Value,
                command.IndicatorTypeId,
                command.ResponsibleId, 
                command.FulfillmentRate,
                command.Cumulative);

            await _repository.SaveAsync(indicator);
        }
    }
}
