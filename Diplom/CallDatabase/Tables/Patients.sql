CREATE TABLE [dbo].[Patients]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[FIO] varchar(max) not null,
	[Age] int not null,
	[StreetId] int not null,
	[HouseNumber] varchar(20) not null,
	[FlatNumber] varchar(20) not null,
	[PassportNumber] varchar(10),
	[Gender] bit not null,
	Constraint [FK_Street] foreign key (StreetId) references Streets (Id),
)
