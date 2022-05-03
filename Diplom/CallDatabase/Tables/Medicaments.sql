CREATE TABLE [dbo].[Medicaments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
    [TreatmentId] int not null,
    [Name] VARCHAR(MAX) NOT NULL, 
    [Dosage] FLOAT NOT NULL,
    Constraint [FK_Treatment] foreign key (TreatmentId) references [dbo].[Treatments] (Id),
)
