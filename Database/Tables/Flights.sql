CREATE TABLE [Flights] (
	[ID] INT PRIMARY KEY IDENTITY,
	[Airline ID] INT NOT NULL REFERENCES [Airlines]([ID]),
	[Origin ID] INT NOT NULL REFERENCES [Airports]([ID]),
	[Destination ID] INT NOT NULL REFERENCES [Airports]([ID]),
	[Depart] DATETIME NOT NULL,
	[Arrive] DATETIME NOT NULL,
	[Outbound] BIT NOT NULL
)
