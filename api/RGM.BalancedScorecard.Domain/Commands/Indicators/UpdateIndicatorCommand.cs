namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;

    public class UpdateIndicatorCommand : IndicatorCommand
    {
        public Guid Id { get; set; }
    }
}
