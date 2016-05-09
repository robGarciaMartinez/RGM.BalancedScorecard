namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class DeleteIndicatorCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
