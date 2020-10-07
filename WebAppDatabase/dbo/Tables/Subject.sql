CREATE TABLE [dbo].[Subject]
(
    [SubjectNumber] INT NOT NULL PRIMARY KEY IDENTITY(1000, 1) , 
    [Gender] NCHAR(7) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [SiteNumber] NCHAR(5) NOT NULL
)
