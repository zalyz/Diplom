CREATE TABLE [dbo].[Medicaments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
    [TreatmentId] int not null,
    [DrugId] int not null,
    Constraint [FK_Treatment] foreign key (TreatmentId) references [dbo].[Treatments] (Id),
    Constraint [FK_Drug] foreign key (DrugId) references [dbo].[Drugs] (Id),
)
