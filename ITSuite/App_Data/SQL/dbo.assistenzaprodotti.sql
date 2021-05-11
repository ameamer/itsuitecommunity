CREATE TABLE [dbo].[assistenzaprodotti] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [idaltrohw]             NVARCHAR (MAX) NULL,
    [idstamp]               NVARCHAR (MAX) NULL,
    [idpc]                  NVARCHAR (MAX) NULL,
    [altra_ass]             NVARCHAR (MAX) NULL,
    [data_apertura]         NVARCHAR (MAX) NULL,
    [ora_apertura]          NVARCHAR (MAX) NULL,
    [autore_apertura]       NVARCHAR (MAX) NULL,
    [intestazione_apertura] NVARCHAR (MAX) NULL,
    [dettagli_apertura]     NVARCHAR (MAX) NULL,
    [dettagli1]             NVARCHAR (MAX) NULL,
    [autore_dettagli1]      NVARCHAR (MAX) NULL,
    [dettagli_chiusura]     NVARCHAR (MAX) NULL,
    [autore_chiusura]       NVARCHAR (MAX) NULL,
    [data_chiusura]         NVARCHAR (MAX) NULL,
    [stato]                 NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

