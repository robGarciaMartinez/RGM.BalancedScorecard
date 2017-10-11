using BalancedScorecard.Domain.Model.Indicators.Values;
using BalancedScorecard.Kernel.Domain;
using System;

namespace BalancedScorecard.Domain.Model.Indicators
{
    public class IndicatorMeasure : BaseEntity
    {
        public IndicatorMeasure(DateTime date, IIndicatorValue record, IIndicatorValue objective, string notes)
        {
            Date = date;
            Record = record;
            Objective = objective;
            Notes = notes;
        }

        public DateTime Date { get; private set; }

        public IIndicatorValue Record { get; private set; }

        public IIndicatorValue Objective { get; private set; }

        public string Notes { get; private set; }
    }
}