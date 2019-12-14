CREATE TABLE [dbo].[DeviceTransaction]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [AccountFK] INT NOT NULL, 
    [ProductFK] INT NOT NULL,
	FOREIGN KEY (AccountFK) REFERENCES Account(Id),
	FOREIGN KEY (ProductFK) REFERENCES Product(Id)

)