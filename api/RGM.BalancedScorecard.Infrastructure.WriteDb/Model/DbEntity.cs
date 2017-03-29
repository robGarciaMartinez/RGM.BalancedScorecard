using System;

namespace RGM.BalancedScorecard.EF.Model
{
    public class DbEntity
    {
        public Guid Id { get; set; }

        public string SerializedObject { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
