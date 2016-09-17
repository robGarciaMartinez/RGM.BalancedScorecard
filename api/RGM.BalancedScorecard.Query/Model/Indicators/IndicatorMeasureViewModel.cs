namespace RGM.BalancedScorecard.Query.Model.Indicators
{
    using System;

    using Domain.Model.Indicators.Values;

    public class IndicatorMeasureViewModel
    {
        public DateTime Date { get; set; }

        public IIndicatorValue Record { get; set; }

        public IIndicatorValue Objective { get; set; }

        public string Notes { get; set; }
    }
}
