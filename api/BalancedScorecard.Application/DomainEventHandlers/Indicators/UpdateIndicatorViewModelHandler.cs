using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using BalancedScorecard.Query.Model;
using BalancedScorecard.Query.Readers.Indicators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BalancedScorecard.Application.DomainEventHandlers.Indicators
{
    public class UpdateIndicatorViewModelHandler : IIntegrationDomainEventHandler<IndicatorMeasureCreatedEvent>
    {
        private readonly IIndicatorCollectionReader _reader;

        public UpdateIndicatorViewModelHandler(IIndicatorCollectionReader reader)
        {
            _reader = reader;
        }

        public async Task Handle(IndicatorMeasureCreatedEvent domainEvent)
        {
            var viewModel = await _reader.GetIndicatorViewModel(domainEvent.IndicatorId);
            if (viewModel == null) throw new ItemNotFoundException("Can't find indicator viewmodel");

            viewModel.Status = domainEvent.IndicatorStatus;
            if (viewModel.Measures == null)
            {
                viewModel.Measures = new List<IndicatorMeasureViewModel>();
            }

            viewModel.Measures.Add(new IndicatorMeasureViewModel
            {
                Date = domainEvent.Date,
                Id = domainEvent.IndicatorMeasureId,
                Notes = domainEvent.Notes,
                ObjectiveValue = domainEvent.ObjectiveValue,
                RealValue = domainEvent.RealValue
            });

            await _reader.ReplaceIndicatorViewModel(viewModel);
        }
    }
}
