namespace RGM.BalancedScorecard.SharedKernel.Domain.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfied(T obj);
    }
}
