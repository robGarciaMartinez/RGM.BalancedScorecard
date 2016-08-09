namespace RGM.BalancedScorecard.SharedKernel.Domain.Validation
{
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public interface ISpecification<in TCommand> where TCommand : ICommand
    {
        bool IsSatisfied(TCommand command);

        string SpecificationMessage { get; }
    }
}
