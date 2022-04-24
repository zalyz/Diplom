CREATE TABLE [dbo].[Treatments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [MedicamentId] INT NOT NULL, 
    [CallId] INT NOT NULL,
    Constraint [FK_Medicaments] Foreign key (MedicamentId) references [dbo].[Medicaments] (Id),
)
