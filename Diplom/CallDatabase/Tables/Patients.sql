CREATE TABLE [dbo].[Patients]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[FIO] nvarchar(max) not null,
	[Age] int not null,
	[StreetId] int not null,
	[HouseNumber] nvarchar(20) not null,
	[FlatNumber] nvarchar(20) not null,
	[PassportNumber] nvarchar(10),
	[Gender] TINYINT not null,
	Constraint [FK_Street] foreign key (StreetId) references Streets (Id),
)
