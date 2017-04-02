using System;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class UpdateIndicatorCommand : IndicatorCommand
    {
        public Guid Id { get; set; }
    }
}
