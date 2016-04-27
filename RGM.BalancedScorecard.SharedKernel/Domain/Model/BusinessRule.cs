// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessRule.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the BusinessRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.SharedKernel.Domain.Model
{
    /// <summary>
    /// The business rule.
    /// </summary>
    public class BusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRule"/> class.
        /// </summary>
        /// <param name="ruleDescription">
        /// The rule description.
        /// </param>
        public BusinessRule(string ruleDescription)
        {
            this.RuleDescription = ruleDescription;
        }

        /// <summary>
        /// Gets the rule description.
        /// </summary>
        public string RuleDescription { get; }
    }
}