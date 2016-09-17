﻿namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    using Domain.Commands.Indicators;
    using Domain.Model.Indicators;
    using Domain.Repositories;
    using Domain.Services.Interfaces;
    using SharedKernel.Domain.Commands;
    using SharedKernel.Domain.Validation;

    public class CreateIndicatorCommandHandler : CommandHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        private readonly IIndicatorStateCalculator stateCalculator;

        public CreateIndicatorCommandHandler(
            IValidator<CreateIndicatorCommand> validator,
            IIndicatorsRepository repository,
            IIndicatorStateCalculator stateCalculator)
            : base(validator)
        {
            this.repository = repository;
            this.stateCalculator = stateCalculator;
        }

        public override void OnSuccessValidation(CreateIndicatorCommand command)
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
                command.Cumulative,
                command.Id);

            indicator.SetState(this.stateCalculator.Calculate(indicator));
            this.repository.Insert(indicator);
        }
    }
}
