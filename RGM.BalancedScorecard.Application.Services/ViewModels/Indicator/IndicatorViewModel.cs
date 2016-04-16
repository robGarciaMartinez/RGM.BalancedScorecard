// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndicatorViewModel.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the IndicatorViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.ApplicationServices.ViewModels.Indicator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RGM.BalancedScorecard.ApplicationServices.ViewModels;
    using RGM.BalancedScorecard.Domain.Indicator;

    /// <summary>
    /// The indicator view model.
    /// </summary>
    public class IndicatorViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Display(Name = "Code")]
        [DataType(DataType.Text)]
        [StringLength(6)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        [Display(Name = "Unit")]
        [DataType(DataType.Text)]
        [StringLength(15)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether active.
        /// </summary>
        [Display(Name = "Active")]
        // [CustomDataType(CDataType.YesNo)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [Display(Name = "StartDate")]
        [DataType(DataType.Date)]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the comparison value type.
        /// </summary>
        [Display(Name = "ComparisonValueType")]
        [EnumDataType(typeof(IndicatorEnum.ComparisonValueType))]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public IndicatorEnum.ComparisonValueType ComparisonValueType { get; set; }

        /// <summary>
        /// Gets or sets the periodicity type.
        /// </summary>
        [Display(Name = "PeriodicityType")]
        [EnumDataType(typeof(IndicatorEnum.PeriodicityType))]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public IndicatorEnum.PeriodicityType PeriodicityType { get; set; }

        /// <summary>
        /// Gets or sets the object value type.
        /// </summary>
        [Display(Name = "ObjectValueType")]
        [EnumDataType(typeof(IndicatorEnum.ObjectValueType))]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public IndicatorEnum.ObjectValueType ObjectValueType { get; set; }

        /// <summary>
        /// Gets or sets the indicator type id.
        /// </summary>
        [Display(Name = "IndicatorType")]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public Guid IndicatorTypeId { get; set; }

        /// <summary>
        /// Gets or sets the manager id.
        /// </summary>
        [Display(Name = "Manager")]
        // [Required(ErrorMessageResourceName = "RequiredField")]
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the fulfillment rate.
        /// </summary>
        [Display(Name = "FulfillmentRate")]
        // [CustomDataType(CDataType.Range)]
        [Range(50, 100)]
        public int? FulfillmentRate { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public IndicatorEnum.State State { get; set; }
    }
}
