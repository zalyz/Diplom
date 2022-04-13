CREATE TABLE [dbo].[AmbulanceBrigades]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [DoktorId] INT NULL,
	[FirstMedicalAssistantId] int null,
	[SecondMedicalAssistantId] int null,
	[Driver] int not null,
	[OrderlyId] int null, 
    [Number] INT NOT NULL, 
    [BrigadeType] TINYINT NOT NULL, 
    [DateTimeStart] DATETIME NOT NULL, 
    [DateTimeEnd] DATETIME NOT NULL, 
    [StationName] NCHAR(10) NULL,
)