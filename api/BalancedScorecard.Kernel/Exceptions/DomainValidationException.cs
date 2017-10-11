using BalancedScorecard.Kernel.Validation;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Exceptions
{
    public class DomainValidationException : Exception
    {
        private List<ValidationError> _errors;

        public DomainValidationException(List<ValidationError> errors)
        {
            _errors = errors;
        }

        public List<ValidationError> Errors => _errors;
    }
}
