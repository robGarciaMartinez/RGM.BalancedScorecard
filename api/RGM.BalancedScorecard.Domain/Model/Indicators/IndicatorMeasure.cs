namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;

    using Values;
    using SharedKernel.Domain.Model;

    public class IndicatorMeasure : AggregateDescendant<Guid>
    {
        public IndicatorMeasure(DateTime date, IIndicatorValue record, IIndicatorValue objective, string notes, Guid id)
            : base(id)
        {
            this.Date = date;
            this.Record = record;
            this.Objective = objective;
            this.Notes = notes;
        }

        public IndicatorMeasure()
        {
        }

        public DateTime Date { get; private set; }

        public IIndicatorValue Record { get; private set; }

        public IIndicatorValue Objective { get; private set; }

        public string Notes { get; private set; }
    }
}