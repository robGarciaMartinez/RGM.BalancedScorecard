namespace RGM.BalancedScorecard.Domain.Specifications.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;
    using RGM.BalancedScorecard.SharedKernel.Guard;

    public class IndicatorCodeMustBeUniqueSpecification : ISpecification<CreateIndicatorCommand>, ISpecification<UpdateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public IndicatorCodeMustBeUniqueSpecification(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public bool IsSatisfied(CreateIndicatorCommand command)
        {
            return this.repository.FindByCode(command.Code) == null;
        }

        public bool IsSatisfied(UpdateIndicatorCommand command)
        {
            var indicator = this.repository.FindByCode(command.Code);
            Guard.AgainstItemNotFound(indicator, "Cannot find an indicator with the given code");

            return indicator.Id == command.Id;
        }

        public string SpecificationMessage => "That indicator code is already in use";
    }
}
