using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedScorecard.Infrastructure.Persistence.Model
{
    public class SnapshotData
    {
        public DateTime Created { get; set; }

        public string AggregateType { get; set; }

        public Guid AggregateId { get; set; }

        public string Snapshot { get; set; }
    }
}
