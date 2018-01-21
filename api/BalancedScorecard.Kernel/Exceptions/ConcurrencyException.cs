using System;

namespace BalancedScorecard.Kernel.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message) { }
    }
}
