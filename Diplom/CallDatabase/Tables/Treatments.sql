CREATE TABLE [dbo].[Treatments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [CallId] INT NOT NULL,
    [DrugId] int not null,
    Constraint [FK_Calls] Foreign key (CallId) references [dbo].[Call] (Id),
    Constraint [FK_Drugs] Foreign key (DrugId) references [dbo].[Drugs] (Id),
)
