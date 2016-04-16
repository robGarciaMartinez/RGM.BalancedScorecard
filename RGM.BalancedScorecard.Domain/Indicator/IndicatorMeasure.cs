// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorMeasure.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorMeasure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Indicator
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain;

    /// <summary>
    /// The indicator measure.
    /// </summary>
    public class IndicatorMeasure : AggregateDescendant<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndicatorMeasure"/> class.
        /// </summary>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="realValue">
        /// The real Value.
        /// </param>
        /// <param name="targetValue">
        /// The target Value.
        /// </param>
        /// <param name="notes">
        /// The notes.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        public IndicatorMeasure(DateTime date, double realValue, double targetValue, string notes, Guid? id = null) : base(id)
        {
            this.Date = date;
            this.RealValue = realValue;
            this.TargetValue = targetValue;
            this.Notes = notes;
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets the real value.
        /// </summary>
        public double? RealValue { get; }

        /// <summary>
        /// Gets the target value.
        /// </summary>
        public double TargetValue { get; }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        public string Notes { get; }

        /// <summary>
        /// The validate.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}
