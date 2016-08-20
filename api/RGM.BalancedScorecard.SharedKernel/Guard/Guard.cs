namespace RGM.BalancedScorecard.SharedKernel.Guard
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Exceptions;

    public static class Guard
    {
        public static void AgainstNullArgument(object obj, string paramName, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void AgainstNullReference(object obj, string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }    
        }

        public static void AgainstInvalidOperation(object obj, string message)
        {
            if (obj == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AgainstItemNotFound(object obj, string message)
        {
            if (obj == null)
            {
                throw new ItemNotFoundException(message);
            }
        }
    }
}
