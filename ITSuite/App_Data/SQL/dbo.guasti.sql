﻿CREATE TABLE [dbo].[guasti] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [data]              NVARCHAR (MAX) NULL,
    [ora]               NVARCHAR (MAX) NULL,
    [padiglione]        NVARCHAR (MAX) NULL,
    [presidio]          NVARCHAR (MAX) NULL,
    [reparto]           NVARCHAR (MAX) NULL,
    [ubicazione_guasto] NVARCHAR (MAX) NULL,
    [intestazione]      NVARCHAR (MAX) NULL,
    [corpo]             NVARCHAR (MAX) NULL,
    [autore_apertura]   NVARCHAR (MAX) NULL,
    [dettagli1]         NVARCHAR (MAX) NULL,
    [autore_dettagli1]  NVARCHAR (MAX) NULL,
    [dettagli2]         NVARCHAR (MAX) NULL,
    [autore_dettagli2]  NVARCHAR (MAX) NULL,
    [dettagli3]         NVARCHAR (MAX) NULL,
    [autore_dettagli3]  NVARCHAR (MAX) NULL,
    [dettagli4]         NVARCHAR (MAX) NULL,
    [autore_dettagli4]  NVARCHAR (MAX) NULL,
    [dettagli5]         NVARCHAR (MAX) NULL,
    [autore_dettagli5]  NVARCHAR (MAX) NULL,
    [motivo]            NVARCHAR (MAX) NULL,
    [datachiusura]      NVARCHAR (MAX) NULL,
    [autorechiusura]    NVARCHAR (MAX) NULL,
    [stato]             NVARCHAR (MAX) NULL,
    [motivoattesa]      NVARCHAR (MAX) NULL,
    [Files]             NVARCHAR (MAX) NULL,
    [FilesTitle]        NVARCHAR (MAX) NULL,
    [utente]            NVARCHAR (MAX) NULL,
    [dettagliutente]    NVARCHAR (MAX) NULL,
    [adminfiles] NVARCHAR(MAX) NULL, 
    [adminfilestitle] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

