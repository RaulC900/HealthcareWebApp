CREATE TABLE [dbo].[SubjectsInventory]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[MedicationId] NCHAR(6) NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 0, 
    [SubjectId] NCHAR(4) NOT NULL, 
    [SiteId] NCHAR(5) NOT NULL
)
