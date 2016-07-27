namespace RGM.BalancedScorecard.SharedKernel.Guard
{
    using System;

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
    }
}
