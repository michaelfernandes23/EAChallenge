CREATE TABLE [dbo].[CarDetails]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[DescriptionId] INT NULL,
	[ImagePath] VARCHAR(200) NULL,
	[ShareLink] VARCHAR(100) NULL,
	[ShareMessageId] INT NULL,
	[Year] INT NULL
)
GO