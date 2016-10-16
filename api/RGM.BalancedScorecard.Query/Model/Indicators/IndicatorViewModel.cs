namespace RGM.BalancedScorecard.Query.Model.Indicators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IndicatorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public int Periodicity { get; set; }

        public int ComparisonValue { get; set; }

        public int ObjectValue { get; set; }

        public Guid IndicatorTypeId { get; set; }

        public Guid ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }

        public int State { get; set; }

        public List<IndicatorMeasureViewModel> Measures { get; set; }

        public string LastMeasureDate
            =>
                this.Measures != null && this.Measures.Any()
                    ? this.Measures.OrderByDescending(m => m.Date).First().Date.ToString("yyyy-MM")
                    : null;
    }
}
