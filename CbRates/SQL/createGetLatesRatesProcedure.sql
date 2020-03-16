CREATE PROCEDURE [dbo].[GetLatestRates]
AS
	SELECT * from CurrencyRates cr order by cr.CR_UpdateDate

	SELECT DISTINCT * FROM CurrencyRates 
  where CAST(CR_UpdateDate AS DATE) = 
  (select top 1  CAST(CR_UpdateDate AS DATE) from CurrencyRates GROUP by CR_UpdateDate ORDER by CR_UpdateDate desc )