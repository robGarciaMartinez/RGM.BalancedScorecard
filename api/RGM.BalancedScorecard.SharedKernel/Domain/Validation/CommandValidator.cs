namespace RGM.BalancedScorecard.SharedKernel.Domain.Validation
{
    using RGM.BalancedScorecard.SharedKernel.DependencyContainer;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CommandValidator<TCommand> : IValidator<TCommand> where TCommand : ICommand
    {
        private readonly IDependencyContainer dependencyContainer;

        public CommandValidator(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public ValidationResult Validate(TCommand command)
        {
            var result = new ValidationResult();
            foreach (var specification in this.dependencyContainer.GetSpecifications<TCommand>())
            {
                if (!specification.IsSatisfied(command))
                {
                    result.AddValidationMessage(specification.SpecificationMessage);
                }
            }

            return result;
        }
    }
}
