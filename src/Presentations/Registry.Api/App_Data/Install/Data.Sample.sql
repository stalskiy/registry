SET IDENTITY_INSERT dbo.AreaType ON; 
INSERT INTO dbo.AreaType ([Id], [Name]) 
	VALUES	(1, N'Земельный участок'),
			(2, N'Единое землепользование'),
			(3, N'Часть земельного участка');
SET IDENTITY_INSERT dbo.AreaType OFF; 

SET IDENTITY_INSERT dbo.AreaOwnershipType ON; 
INSERT INTO dbo.AreaOwnershipType ([Id], [Name]) 
	VALUES	(1, N'Собственность'),
			(2, N'Пожизненное наследуемое владение'),
			(3, N'Постоянное (бессрочное)пользование'),
			(4, N'Аренда'),
			(5, N'Оперативное управление');
SET IDENTITY_INSERT dbo.AreaOwnershipType OFF; 