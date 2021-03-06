﻿CREATE TABLE [Guests] (
	[ID] INT PRIMARY KEY IDENTITY,
	[Created] DATETIME NOT NULL DEFAULT GETDATE(),
	[Depart ID] INT REFERENCES [Flights]([ID]),
	[Return ID] INT REFERENCES [Flights]([ID]),
	[Names] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100)
)
