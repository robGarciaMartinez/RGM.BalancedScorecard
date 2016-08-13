namespace RGM.BalancedScorecard.Domain.Specifications.Indicators
{
    using RGM.BalancedScorecard.Domain.Commands.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

    public class IndicatorUniqueCodeSpecification : ISpecification<CreateIndicatorCommand>
    {
        private readonly IIndicatorsRepository repository;

        public IndicatorUniqueCodeSpecification(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public bool IsSatisfied(CreateIndicatorCommand command)
        {
            return this.repository.FindByCode(command.Code) == null;
        }

        public string SpecificationMessage => "That indicator code is already in use";
    }
}
