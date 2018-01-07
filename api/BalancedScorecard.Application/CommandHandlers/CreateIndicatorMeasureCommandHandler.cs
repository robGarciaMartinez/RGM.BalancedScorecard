using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.CommandHandlers
{
    public class CreateIndicatorMeasureCommandHandler : ICommandHandler<CreateIndicatorMeasureCommand>
    {
        private readonly IRepository<Indicator> _repository;

        public CreateIndicatorMeasureCommandHandler(
            IRepository<Indicator> repository)
        {
            _repository = repository;
        }

        public async Task Execute(CreateIndicatorMeasureCommand command)
        {
            if (command == null) throw new ArgumentNullException("Command can't be null");

            var indicator = await _repository.GetById(command.IndicatorId);
            if (indicator == null)
            {
                throw new ItemNotFoundException("Indicator not found");
            }

            indicator.AddMeasure(command.Date.Value, command.RealValue, command.ObjectiveValue, command.Notes);
            await _repository.SaveAsync(indicator);
        }
    }
}
