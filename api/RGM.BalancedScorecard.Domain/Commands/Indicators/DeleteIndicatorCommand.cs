using System;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class DeleteIndicatorCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}
