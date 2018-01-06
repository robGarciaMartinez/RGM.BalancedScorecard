using BalancedScorecard.Kernel.Validation;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Exceptions
{
    public class ValidationException : Exception
    {
        private List<ValidationError> _errors;

        public ValidationException(List<ValidationError> errors)
        {
            _errors = errors;
        }

        public List<ValidationError> Errors => _errors;
    }
}
