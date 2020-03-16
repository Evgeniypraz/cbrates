CREATE TABLE [dbo].[CurrencyRates] (
    [CR_id]           INT            IDENTITY (1, 1) NOT NULL,
    [CR_CurrencyName] NVARCHAR (MAX) COLLATE Cyrillic_General_CI_AS_KS NULL,
    [CR_CurrencyIso]  INT            NULL,
    [CR_FaceVAlue]    DECIMAL (18)   NULL,
    [CR_StringCode]   VARCHAR (50)   NULL,
    [CR_Rate]         DECIMAL (18)   NULL,
    [CR_UpdateDate]   DATETIME       NULL,
    CONSTRAINT [PK_CurrencyRates] PRIMARY KEY CLUSTERED ([CR_id] ASC)
);

