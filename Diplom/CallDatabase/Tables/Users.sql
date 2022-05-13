CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity (1, 1),
	[MedicalAssistantId] int null,
	[Login] nvarchar(max) not null,
	[PasswordHash] varchar(max) not null,
	Constraint [FK_MedicalAssistant] foreign key (MedicalAssistantId) references MedicalAssistants (Id)
)
