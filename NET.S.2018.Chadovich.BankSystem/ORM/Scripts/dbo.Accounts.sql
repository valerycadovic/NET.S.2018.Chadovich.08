CREATE TABLE [dbo].[Accounts] (
    [IBAN]           NVARCHAR (50)   NOT NULL,
    [Bonuses]        INT             NOT NULL,
    [Balance]        DECIMAL (16, 2) NOT NULL,
    [IsActive]       BIT             NOT NULL,
    [HolderId]       NVARCHAR (50)   NOT NULL,
    [TypeSettingsId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([IBAN] ASC),
    CONSTRAINT [FK_Accounts_TypeSettings] FOREIGN KEY ([TypeSettingsId]) REFERENCES [dbo].[TypeSettings] ([Id]),
    CONSTRAINT [FK_Accounts_Holders] FOREIGN KEY ([HolderId]) REFERENCES [dbo].[Holders] ([PassportId])
);

