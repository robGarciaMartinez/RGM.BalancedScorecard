// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorMeasure.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorMeasure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Model.Indicators.Measures
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    /// <summary>
    ///     The indicator measure.
    /// </summary>
    public class IndicatorMeasure<TValue> : AggregateDescendant<Guid>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndicatorMeasure{TValue}" /> class.
        /// </summary>
        /// <param name="date">
        ///     The date.
        /// </param>
        /// <param name="value">
        ///     The value.
        /// </param>
        /// <param name="notes">
        ///     The notes.
        /// </param>
        /// <param name="id">
        ///     The id.
        /// </param>
        public IndicatorMeasure(DateTime date, TValue value, string notes, Guid id)
            : base(id)
        {
            this.Date = date;
            this.Value = value;
            this.Notes = notes;
        }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        ///     Gets the notes.
        /// </summary>
        public string Notes { get; }

        /// <summary>
        ///     The validate.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}