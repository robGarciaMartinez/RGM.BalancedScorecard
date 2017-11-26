CREATE TABLE Events(
  Id uniqueidentifier not null,
  Created datetime not null,
  AggregateType nvarchar(100) not null,
  AggregateId uniqueidentifier not null,
  Version int not null,
  Event nvarchar(MAX) not null,
  MetaData nvarchar(MAX) null,
  Constraint PKEvents PRIMARY KEY(Id)
)
GO

CREATE INDEX Idx_Events_AggregateId
ON Events(AggregateId)
GO

CREATE TABLE Snapshots(
  AggregateType nvarchar(100) not null,
  AggregateId uniqueidentifier not null,
  Version int not null,
  Snapshot nvarchar(MAX) not null,
  Constraint PKSnapshots PRIMARY KEY(AggregateId)
)
GO