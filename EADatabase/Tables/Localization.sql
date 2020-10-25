CREATE TABLE [dbo].[Localization]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[LocalizationSetId] INT NOT NULL,
	[CultureCode] VARCHAR(10) NOT NULL,
	[Value] NVARCHAR(1000) NULL
)
GO
ALTER TABLE [dbo].[Localization] ADD CONSTRAINT [FK_Localization_LocalizationSet] FOREIGN KEY([LocalizationSetId])
REFERENCES [dbo].[LocalizationSet] ([Id])
GO
ALTER TABLE [dbo].[Localization] CHECK CONSTRAINT [FK_Localization_LocalizationSet]
GO

ALTER TABLE [dbo].[Localization] ADD CONSTRAINT [FK_Localization_Culture] FOREIGN KEY([CultureCode])
REFERENCES [dbo].[Culture] ([Code])
GO
ALTER TABLE [dbo].[Localization] CHECK CONSTRAINT [FK_Localization_Culture]
GO
