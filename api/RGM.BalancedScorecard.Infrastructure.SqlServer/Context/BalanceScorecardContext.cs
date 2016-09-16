﻿using System.Data.Entity;
using RGM.BalancedScorecard.Domain.Model.Indicators;

namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Context
{
    using Microsoft.Extensions.Configuration;

    public class BalancedScorecardContext : DbContext, IDbContext
    {
        public BalancedScorecardContext(IConfiguration configuration,
            IDatabaseInitializer<BalancedScorecardContext> dbInitializer)
            : base(configuration.GetValue<string>("SqlServer:ConnectionString"))
        {
            Database.SetInitializer(dbInitializer);
        }

        public DbSet<Indicator> Indicators { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indicator>()
               .ToTable("Indicators");
            modelBuilder.Entity<Indicator>().Property(i => i.Code).IsRequired();
            modelBuilder.Entity<Indicator>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<Indicator>().Property(i => i.Description).IsRequired();
            modelBuilder.Entity<Indicator>().Property(i => i.Unit).IsRequired();
            modelBuilder.Entity<Indicator>().Ignore(i => i.Events);

            modelBuilder.Entity<IndicatorMeasure>()
               .ToTable("IndicatorMeasures");
            modelBuilder.Entity<IndicatorMeasure>()
                .HasRequired(im => im.Indicator)
                .WithMany(i => i.Measures)
                .HasForeignKey(im => im.IndicatorId);
            modelBuilder.Entity<IndicatorMeasure>().Ignore(i => i.State);
        }
    }
}
