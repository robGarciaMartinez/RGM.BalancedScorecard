using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Kernel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedScorecard.Query.Model.Indicators
{
    public class IndicatorViewModel : IViewModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public int? PeriodicityTypeId { get; set; }

        public int? ComparisonTypeId { get; set; }

        public int? IndicatorValueTypeId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }

        public IndicatorEnum.Status? Status { get; set; }

        public ICollection<IndicatorMeasureViewModel> Measures { get; set; }
    }

    public class IndicatorMeasureViewModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public object RealValue { get; set; }

        public object ObjectiveValue { get; set; }

        public string Notes { get; set; }
    }

    public class IndicatorReferenceDataViewModel
    {
        public IEnumerable<SelectListViewModel> PeriodicityTypes =>
            Enum.GetValues(typeof(IndicatorEnum.PeriodicityType))
                .OfType<IndicatorEnum.PeriodicityType>()
                .Select(pt => new SelectListViewModel((int)pt, pt.ToString()));

        public IEnumerable<SelectListViewModel> ComparisonTypes =>
            Enum.GetValues(typeof(IndicatorEnum.ComparisonType))
                .OfType<IndicatorEnum.ComparisonType>()
                .Select(ct => new SelectListViewModel((int)ct, ct.ToString()));

        public IEnumerable<SelectListViewModel> IndicatorValueTypes =>
            Enum.GetValues(typeof(IndicatorEnum.IndicatorValueType))
                .OfType<IndicatorEnum.IndicatorValueType>()
                .Select(ivt => new SelectListViewModel((int)ivt, ivt.ToString()));
    }
}
