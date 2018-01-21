﻿using System;

namespace BalancedScorecard.Infrastructure.SqlServerDb.Model
{
    public class EventData
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string AggregateType { get; set; }

        public Guid AggregateId { get; set; }

        public int Version { get; set; }

        public string Event { get; set; }

        public string Metadata { get; set; }
    }
}
