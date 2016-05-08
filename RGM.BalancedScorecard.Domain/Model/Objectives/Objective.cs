namespace RGM.BalancedScorecard.Domain.Model.Objectives
{
    using System;
    using System.Collections.Generic;

    using RGM.BalancedScorecard.Domain.Model.Indicators;
    using RGM.BalancedScorecard.SharedKernel.Domain;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public class Objective : AggregateRoot<Guid>
    {
        public Objective(string name, string description, DateTime startDate, DateTime endDate, string code, Guid objectiveTypeId, Guid responsibleId)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Code = code;
            this.ObjectiveTypeId = objectiveTypeId;
            this.ResponsibleId = responsibleId;
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
            
        protected override void Validate()
        {
            
        }
    }
}
