CREATE TABLE [dbo].[GlobalSettings]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1, 1), 
    [SettingName] nVARCHAR(500) NOT NULL, 
    [SettingValue] nVARCHAR(500) NOT NULL
)
