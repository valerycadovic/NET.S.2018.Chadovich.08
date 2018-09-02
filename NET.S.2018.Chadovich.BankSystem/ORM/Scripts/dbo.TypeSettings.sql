CREATE TABLE [dbo].[TypeSettings] (
    [Id]             INT           NOT NULL,
    [WithdrawalCost] INT           NOT NULL,
    [DepositCost]    INT           NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

