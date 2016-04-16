// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeIndicatorRepository.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the FakeIndicatorRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rgm.BalancedScorecard.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RGM.BalancedScorecard.Domain.Indicator;
    using RGM.BalancedScorecard.Domain.Infrastructure;
    using RGM.BalancedScorecard.Domain.User;

    /// <summary>
    /// The indicator repository.
    /// </summary>
    public class FakeIndicatorRepository : IIndicatorRepository
    {
        /// <summary>
        /// The find by key.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Indicator"/>.
        /// </returns>
        public Indicator FindByKey(Guid id)
        {
            return this.GetAllIndicators().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// The find by code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="Indicator"/>.
        /// </returns>
        public Indicator FindByCode(string code)
        {
            return this.GetAllIndicators().FirstOrDefault(i => i.Code == code);
        }

        /// <summary>
        /// The find all.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IndicatorSearchResult"/>.
        /// </returns>
        public IndicatorSearchResult FindAll(IndicatorFilterCriteria filter)
        {
            return null;
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="domainEntity">
        /// The aggregate root.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public Guid Insert(Indicator domainEntity)
        {
            return domainEntity.Id.Value;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="domainEntity">
        /// The aggregate root.
        /// </param>
        public void Update(Indicator domainEntity)
        {
            return;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(Guid id)
        {
            return;
        }

        /// <summary>
        /// The get all indicators.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<Indicator> GetAllIndicators()
        {
            return new List<Indicator>()
                       {
                           new Indicator(
                               Guid.NewGuid(),
                               "Indicator1",
                               "Description1",
                               DateTime.Today,
                               "Code1",
                               "£",
                               IndicatorEnum.PeriodicityType.Month,
                               IndicatorEnum.ComparisonValueType.Greater,
                               IndicatorEnum.ObjectValueType.Decimal,
                               Guid.NewGuid(),
                               Guid.NewGuid(),
                               null,
                               false,
                               new List<IndicatorMeasure>()
                                   {
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           1,
                                           1,
                                           "Notes1"),
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           2,
                                           2,
                                           "Notes2")
                                   },
                               new User(Guid.NewGuid())),
                           new Indicator(
                               Guid.NewGuid(),
                               "Indicator2",
                               "Description2",
                               DateTime.Today,
                               "Code2",
                               "£",
                               IndicatorEnum.PeriodicityType.Month,
                               IndicatorEnum.ComparisonValueType.Greater,
                               IndicatorEnum.ObjectValueType.Decimal,
                               Guid.NewGuid(),
                               Guid.NewGuid(),
                               null,
                               false,
                               new List<IndicatorMeasure>()
                                   {
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           1,
                                           1,
                                           "Notes1"),
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           2,
                                           2,
                                           "Notes2")
                                   },
                               new User(Guid.NewGuid())),
                            new Indicator(
                               Guid.NewGuid(),
                               "Indicator3",
                               "Description3",
                               DateTime.Today,
                               "Code3",
                               "£",
                               IndicatorEnum.PeriodicityType.Month,
                               IndicatorEnum.ComparisonValueType.Greater,
                               IndicatorEnum.ObjectValueType.Decimal,
                               Guid.NewGuid(),
                               Guid.NewGuid(),
                               null,
                               false,
                               new List<IndicatorMeasure>()
                                   {
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           1,
                                           1,
                                           "Notes1"),
                                       new IndicatorMeasure(
                                           Guid.NewGuid(),
                                           DateTime.Today,
                                           2,
                                           2,
                                           "Notes2")
                                   },
                               new User(Guid.NewGuid()))
                       };
        } 
    }
}
