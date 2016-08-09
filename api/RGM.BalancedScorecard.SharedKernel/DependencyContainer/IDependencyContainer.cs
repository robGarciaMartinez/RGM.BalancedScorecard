namespace RGM.BalancedScorecard.SharedKernel.DependencyContainer
{
    using System.Collections.Generic;

    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;
    using RGM.BalancedScorecard.SharedKernel.Domain.Validation;

    public interface IDependencyContainer
    {
        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;

        IValidator<TCommand> GetValidator<TCommand>() where TCommand : ICommand;

        IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() where TCommand : ICommand;
    }
}
