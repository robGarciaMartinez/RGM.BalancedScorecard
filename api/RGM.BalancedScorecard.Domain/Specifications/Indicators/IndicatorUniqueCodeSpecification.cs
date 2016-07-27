namespace RGM.BalancedScorecard.Domain.Specifications.Indicators
{
    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.Domain.Repositories;
    using RGM.BalancedScorecard.SharedKernel.Domain.Specification;

    public class IndicatorUniqueCodeSpecification : ISpecification<Indicator>
    {
        private readonly IIndicatorsRepository repository;

        public IndicatorUniqueCodeSpecification(IIndicatorsRepository repository)
        {
            this.repository = repository;
        }

        public bool IsSatisfied(Indicator obj)
        {
            return this.repository.FindByCode(obj.Code) == null;
        }
    }
}
