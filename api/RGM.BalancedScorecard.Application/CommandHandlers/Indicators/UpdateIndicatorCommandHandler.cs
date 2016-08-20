namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

    public class UpdateIndicatorCommandHandler : CommandHandler<UpdateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public UpdateIndicatorCommandHandler(
            IValidator<UpdateIndicatorCommand> validator,
            IIndicatorsRepository repository)
            : base(validator)
        {
            this.repository = repository;
        }

        public override void OnSuccessValidation(UpdateIndicatorCommand command)
        {
            var indicator = this.repository.FindByKey(command.Id);
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

            this.repository.Update(indicator);
        }
    }
}
