CREATE TABLE [dbo].[Treatments]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [CallId] INT NOT NULL,
    Constraint [FK_Calls] Foreign key (CallId) references [dbo].[Call] (Id),
)
