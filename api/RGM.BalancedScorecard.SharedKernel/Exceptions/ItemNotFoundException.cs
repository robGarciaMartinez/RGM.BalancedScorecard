namespace RGM.BalancedScorecard.SharedKernel.Exceptions
{
    using System;

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message): base(message) { }
    }
}
