namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;

    using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public class IndicatorMeasure : AggregateDescendant<Guid>
    {
        public IndicatorMeasure(Guid indicatorId, DateTime date, IValue record, IValue objective, string notes, Guid id)
            : base(id)
        {
            this.IndicatorId = indicatorId;
            this.Date = date;
            this.Record = record;
            this.Objective = objective;
            this.Notes = notes;
        }

        public IndicatorMeasure()
        {
        }

        public Guid IndicatorId { get; private set; }

        public DateTime Date { get; private set; }

        public IValue Record { get; private set; }

        public IValue Objective { get; private set; }

        public string Notes { get; private set; }

        public Indicator Indicator { get; private set; }
    }
}