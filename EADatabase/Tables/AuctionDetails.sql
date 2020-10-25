CREATE TABLE [dbo].[AuctionDetails]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[CarDetailsId] INT NOT NULL,
	[Bids] INT,
	[EndDate] Datetime NULL,
	[Lot] INT NULL,
	[CurrentPrice] INT NULL,
	[CurrencyId] INT NULL,
	[VinNumber] VARCHAR(100) NULL
)
GO
ALTER TABLE [dbo].[AuctionDetails] ADD CONSTRAINT [FK_AuctionDetails_CarDetails] FOREIGN KEY([CarDetailsId])
REFERENCES [dbo].[CarDetails] ([Id])
GO
ALTER TABLE [dbo].[AuctionDetails] CHECK CONSTRAINT [FK_AuctionDetails_CarDetails]
GO