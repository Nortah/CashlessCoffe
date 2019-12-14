CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(25) NOT NULL, 
    [Price] DECIMAL NULL
)
CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TotalAmount] DECIMAL NULL
)
CREATE TABLE [dbo].[DeviceTransaction]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [AccountFK] INT NOT NULL, 
    [ProductFK] INT NOT NULL,
	FOREIGN KEY (AccountFK) REFERENCES Account(Id),
	FOREIGN KEY (ProductFK) REFERENCES Product(Id)

)

INSERT INTO Product(Id, Name, Price)
VALUES (0, 'Coffee', 2.0);
INSERT INTO Product(Id, Name, Price)
VALUES (1, 'Cappuccino', 2.5);
INSERT INTO Product(Id, Name, Price)
VALUES (2, 'Espresso', 1.5);

INSERT INTO Account(Id, TotalAmount)
VALUES (0, 30.0);
INSERT INTO Account(Id, TotalAmount)
VALUES (1, 30.0);
INSERT INTO Account(Id, TotalAmount)
VALUES (2, 30.0);


INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (0, '20191201', 0, 1); 
INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (1, '20191201', 0, 0); 
INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (2, '20191201', 2, 1); 
INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (3, '20191101', 1, 2); 
INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (4, '20191101', 2, 1); 
INSERT INTO DeviceTransaction (Id, Date, AccountFK, ProductFK)
VALUES (5, '20191101', 0, 2); 