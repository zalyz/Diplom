CREATE TABLE [dbo].[AmbulanceBrigades]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [DoktorId] INT NULL,
	[FirstMedicalAssistantId] int null,
	[SecondMedicalAssistantId] int null,
	[DriverId] int not null,
	[OrderlyId] int null, 
    [Number] INT NOT NULL, 
    [BrigadeType] TINYINT NOT NULL, 
    [DateTimeStart] DATETIME NOT NULL, 
    [DateTimeEnd] DATETIME NOT NULL, 
    [StationName] varchar(50) NULL,
    Constraint [FK_Doktors] Foreign key (DoktorId) references [dbo].[Doktors] (Id),
    Constraint [FK_FirstMA] Foreign key (FirstMedicalAssistantId) references [dbo].[MedicalAssistants] (Id),
    Constraint [FK_SecondMA] Foreign key (SecondMedicalAssistantId) references [dbo].[MedicalAssistants] (Id),
    Constraint [FK_Drivers] Foreign key (DriverId) references [dbo].[Drivers] (Id),
    Constraint [FK_Orderlies] Foreign key (OrderlyId) references [dbo].[Orderlies] (Id),
)