namespace RGM.BalancedScorecard.SharedKernel.Infrastructure
{
    using System;

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message): base(message) { }
    }
}
