using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using System;

namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    public class IndicatorMeasure : DomainEntity
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