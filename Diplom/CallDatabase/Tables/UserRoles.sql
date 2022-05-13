CREATE TABLE [dbo].[UserRoles]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[UserId] int not null,
	[RoleId] int not null,
	constraint [FK_Users] foreign key (UserId) references Users (Id),
	constraint [FK_Roles] foreign key (RoleId) references Roles (Id)
)
