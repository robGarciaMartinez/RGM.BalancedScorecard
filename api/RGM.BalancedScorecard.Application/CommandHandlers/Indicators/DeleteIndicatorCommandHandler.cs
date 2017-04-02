using RGM.BalancedScorecard.Domain.Commands.Indicators;
using RGM.BalancedScorecard.Domain.Model.Indicators;
using RGM.BalancedScorecard.Domain.Services.Abstractions;
using RGM.BalancedScorecard.Kernel.Domain.Commands;
using RGM.BalancedScorecard.Kernel.Domain.Validation;
using System;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Application.CommandHandlers.Indicators
{
    public class DeleteIndicatorCommandHandler : BaseCommandHandler<DeleteIndicatorCommand>
    {
        private readonly IAggregateRootRepository<Indicator> _repository;

        public DeleteIndicatorCommandHandler(IValidator<DeleteIndicatorCommand> validator, IAggregateRootRepository<Indicator> repository)
            : base(validator)
        {
            _repository = repository;
        }

        public override Task OnSuccessfulValidation(DeleteIndicatorCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
