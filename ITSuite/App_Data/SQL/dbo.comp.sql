CREATE TABLE [dbo].[comp] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (MAX) NULL,
    [dev]           NVARCHAR (MAX) NULL,
    [link]          NVARCHAR (MAX) NULL,
    [devaddr]       NVARCHAR (MAX) NULL,
    [tname]         NVARCHAR (MAX) NULL,
    [tktusers]      NVARCHAR (50)  NULL,
    [customerusers] NVARCHAR (50)  NULL,
    [securitypass]  NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);