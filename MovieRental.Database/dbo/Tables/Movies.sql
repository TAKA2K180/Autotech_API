CREATE TABLE [dbo].[Movies] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (MAX)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [Price]       DECIMAL (18, 2)  NULL,
    [Category]    NVARCHAR (MAX)   NOT NULL,
    [DateCreated] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

