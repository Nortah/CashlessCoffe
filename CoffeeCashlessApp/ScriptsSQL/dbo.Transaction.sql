CREATE TABLE [dbo].[Transaction]
(
	[IdTransaction] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [IdAccount] INT NOT NULL, 
    [IdProduct] INT NOT NULL
	-- FOREIGN KEY
)
