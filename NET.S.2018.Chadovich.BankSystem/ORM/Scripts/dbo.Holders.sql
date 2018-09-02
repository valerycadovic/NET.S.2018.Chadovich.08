CREATE TABLE [dbo].[Holders] (
    [PassportId]  NVARCHAR (50) NOT NULL,
    [FullName]    NVARCHAR (50) NOT NULL,
	[Email]		  NVARCHAR (50) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    [AccountIBAN] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PassportId] ASC)
);

