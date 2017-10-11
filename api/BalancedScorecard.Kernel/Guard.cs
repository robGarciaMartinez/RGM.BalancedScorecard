using System;

namespace BalancedScorecard.Kernel
{
    public static class Guard
    {
        public static void AgainstInvalidOperationException(object obj, string message)
        {
            if (obj == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AgainstNullReferenceException(object obj, string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void AgainstArgumentNullException(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void AgainstArgumentException(bool condition, string message)
        {
            if (condition)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
