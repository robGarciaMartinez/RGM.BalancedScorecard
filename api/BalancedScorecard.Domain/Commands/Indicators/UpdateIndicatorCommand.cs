using System;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class UpdateIndicatorCommand : IndicatorCommand
    {
        public Guid Id { get; set; }
    }
}
