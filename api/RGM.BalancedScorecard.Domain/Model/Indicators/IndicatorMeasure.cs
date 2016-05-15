// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorMeasure.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorMeasure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    /// <summary>
    ///     The indicator measure.
    /// </summary>
    public class IndicatorMeasure : AggregateDescendant<Guid>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IndicatorMeasure" /> class.
        /// </summary>
        /// <param name="date">
        ///     The date.
        /// </param>
        /// <param name="record">
        ///     The record.
        /// </param>
        /// <param name="objective">
        ///     The objecive.
        /// </param> 
        /// <param name="notes">
        ///     The notes.
        /// </param>
        /// <param name="id">
        ///     The id.
        /// </param>
        public IndicatorMeasure(DateTime date, IValue record, IValue objective, string notes, Guid id)
            : base(id)
        {
            this.Date = date;
            this.Record = record;
            this.Objective = objective;
            this.Notes = notes;
        }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        ///     Gets the record.
        /// </summary>
        public IValue Record { get; private set; }

        /// <summary>
        ///     Gets the objective.
        /// </summary>
        public IValue Objective { get; private set; }

        /// <summary>
        ///     Gets the notes.
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        ///     The validate.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}