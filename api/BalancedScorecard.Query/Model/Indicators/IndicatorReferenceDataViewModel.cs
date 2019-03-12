using BalancedScorecard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedScorecard.Query.Model.Indicators
{
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
