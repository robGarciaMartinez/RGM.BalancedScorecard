using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Commands;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using BalancedScorecard.Kernel.Validation;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class CreateIndicatorCommandHandler : ICommandHandler<CreateIndicatorCommand>
    {
        private readonly IValidator<CreateIndicatorCommand> _validator;
        private readonly IRepository<Indicator> _repository;

        public CreateIndicatorCommandHandler(
            IValidator<CreateIndicatorCommand> validator,
            IRepository<Indicator> repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task Execute(CreateIndicatorCommand command)
        {
            if (command == null) throw new ArgumentNullException("Command can't be null");

            var validationResult = await _validator.Validate(command);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var indicator = new Indicator(
                    command.IndicatorId,
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

            await  _repository.SaveAsync(indicator);
        }
    }
}
