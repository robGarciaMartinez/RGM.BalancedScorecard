﻿namespace RGM.BalancedScorecard.Kernel.Domain.Commands
{
    public interface ICommand
    {
        string RequestedBy { get; set; }
    }
}
