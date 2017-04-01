CREATE TABLE [dbo].[Indicators]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SerializedObject] NVARCHAR(MAX) NOT NULL CONSTRAINT [Indicator_IsJson] CHECK (ISJSON(SerializedObject)> 0), 
	[CreatedOn] DATETIME NOT NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL, 
    [UpdatedOn] DATETIME NULL, 
    [UpdatedBy] NVARCHAR(100) NULL
)
