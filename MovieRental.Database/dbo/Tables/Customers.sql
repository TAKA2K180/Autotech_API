CREATE TABLE [dbo].[Customers] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    [Email]    NVARCHAR (MAX)   NOT NULL,
    [Phone]    NVARCHAR (MAX)   NOT NULL,
    [isActive] BIT              NOT NULL,
    CONSTRAINT [PK_Costumers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

