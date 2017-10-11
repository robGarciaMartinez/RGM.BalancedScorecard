using System.Collections.Generic;
using System.Linq;

namespace BalancedScorecard.Kernel.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }

        public List<ValidationError> Errors { get; set; }

        public bool IsValid => Errors == null || !Errors.Any();
    }
}
