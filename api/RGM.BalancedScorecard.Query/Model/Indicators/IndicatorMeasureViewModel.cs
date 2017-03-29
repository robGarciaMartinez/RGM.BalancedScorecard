using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
using System;

namespace RGM.BalancedScorecard.Query.Model.Indicators
{
    public class IndicatorMeasureViewModel
    {
        public DateTime Date { get; set; }

        public IIndicatorValue Record { get; set; }

        public IIndicatorValue Objective { get; set; }

        public string Notes { get; set; }
    }
}
