CREATE FUNCTION [dbo].[GetCarsWithAuctionDetails](@CultureCode varchar(10))
RETURNS TABLE AS RETURN
SELECT b.Id, lDescription.Value AS [Description], lShareMessage.Value AS ShareMessage
FROM CarDetails AS b
	INNER JOIN Localization AS lDescription ON b.DescriptionId = lDescription.LocalizationSetId
	INNER JOIN Localization AS lShareMessage ON b.ShareMessageId = lShareMessage.LocalizationSetId
WHERE lDescription.CultureCode = @CultureCode AND lShareMessage.CultureCode = @CultureCode