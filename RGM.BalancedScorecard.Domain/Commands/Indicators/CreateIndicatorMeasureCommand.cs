namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorMeasureCommand : ICommand
    {
        public Guid IndicatorId { get; set; }
    }
}
