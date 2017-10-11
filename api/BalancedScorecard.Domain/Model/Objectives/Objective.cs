using BalancedScorecard.Domain.Model.Indicators;
using BalancedScorecard.Kernel.Domain;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Domain.Model.Objectives
{
    public class Objective : AggregateRoot
    {
        public Objective(string name, string description, DateTime startDate, DateTime endDate, string code, Guid objectiveTypeId, Guid responsibleId)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Code = code;
            ObjectiveTypeId = objectiveTypeId;
            ResponsibleId = responsibleId;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public string Code { get; private set; }

        public Guid ObjectiveTypeId { get; private set; }

        public Guid ResponsibleId { get; private set; }

        public List<Objective> Objectives { get; set; }

        public List<Indicator> Indicators { get; set; }
    }
}
