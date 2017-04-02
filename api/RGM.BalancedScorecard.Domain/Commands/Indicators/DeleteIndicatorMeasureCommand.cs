using System;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class DeleteIndicatorMeasureCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}
