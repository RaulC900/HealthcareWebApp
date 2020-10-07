CREATE TABLE [dbo].[SitesInventory]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[MedicationId] NCHAR(6) NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 0, 
    [SiteId] NCHAR(5) NOT NULL
)
