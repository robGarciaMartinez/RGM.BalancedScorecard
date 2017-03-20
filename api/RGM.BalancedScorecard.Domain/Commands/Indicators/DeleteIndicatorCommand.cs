using RGM.BalancedScorecard.Kernel.Domain.Commands;
using System;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class DeleteIndicatorCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
