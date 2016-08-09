namespace RGM.BalancedScorecard.SharedKernel.Domain.Validation
{
    using System.Collections.Generic;
    using System.Linq;

    public class ValidationResult
    {
        public List<string> ValidationMessages { get; private set; }

        public bool IsValid => this.ValidationMessages == null || !this.ValidationMessages.Any();

        public void AddValidationMessage(string message)
        {
            if (this.ValidationMessages == null)
            {
                this.ValidationMessages = new List<string>();
            }

            this.ValidationMessages.Add(message);
        }
    }
}
