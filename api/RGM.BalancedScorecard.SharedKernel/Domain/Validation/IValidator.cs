namespace RGM.BalancedScorecard.SharedKernel.Domain.Validation
{
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public interface IValidator <in TCommand> where TCommand : ICommand
    {
        ValidationResult Validate(TCommand command);
    }
}
