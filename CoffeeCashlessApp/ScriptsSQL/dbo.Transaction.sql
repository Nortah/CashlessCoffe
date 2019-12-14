CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [IdAccount] INT NOT NULL, 
    [IdTransaction] INT NOT NULL
)
