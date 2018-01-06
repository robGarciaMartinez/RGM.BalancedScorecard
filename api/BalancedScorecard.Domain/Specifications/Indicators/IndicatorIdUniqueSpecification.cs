using BalancedScorecard.Domain.Commands.Indicators;
using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Validation;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Domain.Specifications
{
    public class IndicatorIdUniqueSpecification : ISpecification<CreateIndicatorCommand>
    {
        private readonly IRepository<Indicator> _repository;

        public IndicatorIdUniqueSpecification(IRepository<Indicator> repository)
        {
            _repository = repository;
        }

        public string ErrorMessage => $"An indicator with the same id already exists.";

        public async Task<bool> IsSatisfiedBy(CreateIndicatorCommand command)
        {
            if (command == null) throw new ArgumentNullException("Command can't be null");
            if (command.Id == null) throw new ArgumentException("Command Id can't be null");

            return await _repository.GetById(command.Id.Value) == null;
        }
    }
}
