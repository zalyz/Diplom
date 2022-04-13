CREATE TABLE [dbo].[GlobalSettings]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [SettingName] VARCHAR(500) NOT NULL, 
    [SettingValue] VARCHAR(500) NOT NULL
)
