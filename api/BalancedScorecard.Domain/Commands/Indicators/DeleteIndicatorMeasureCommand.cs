using System;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class DeleteIndicatorMeasureCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}
