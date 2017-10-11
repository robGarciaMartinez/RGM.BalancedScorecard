using BalancedScorecard.Kernel.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancedScorecard.Kernel.Validation
{
    public class BaseValidator<TCommand> : IValidator<TCommand>
        where TCommand : ICommand
    {
        protected readonly IValidationDependencyContainer _container;

        public BaseValidator(IValidationDependencyContainer container)
        {
            _container = container;
        }

        public async Task<ValidationResult> Validate(TCommand command)
        {
            var validationResult = new ValidationResult();
            var specifications = GetSpecifications<TCommand>().ToList();
            var tasks = new Task<bool>[specifications.Count];

            foreach (var index in Enumerable.Range(0, specifications.Count))
            {
                tasks[index] = specifications[index].IsSatisfiedBy(command);
            }

            await Task.WhenAll(tasks.ToArray());

            foreach(var index in Enumerable.Range(0, tasks.Length))
            {
                var isSatisfiedBy = tasks[index].Result;
                if (!isSatisfiedBy)
                {
                    validationResult.Errors.Add(
                        new ValidationError(specifications[index].GetType().Name, specifications[index].ErrorMessage));
                }
            }

            return validationResult;
        }

        protected virtual IEnumerable<ISpecification<TC>> GetSpecifications<TC>()
            where TC : ICommand
        {
            return _container.GetSpecifications<TC>();
        }
    }
}
