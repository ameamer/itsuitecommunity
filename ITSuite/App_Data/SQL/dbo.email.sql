CREATE TABLE [dbo].[email]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL, 
    [sendermail] NVARCHAR(MAX) NULL, 
    [mail] NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
