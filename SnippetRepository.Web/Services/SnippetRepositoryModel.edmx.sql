
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/31/2011 18:38:34
-- Generated from EDMX file: C:\DansFolder\Projects\SnippetRepository\SnippetRepository.Web\Services\SnippetRepositoryModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SnippetRepository];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Snippets'
CREATE TABLE [dbo].[Snippets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Usage] nvarchar(max)  NULL,
    [Tags] nvarchar(max)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [DateModified] datetime  NULL,
    [Views] smallint  NOT NULL,
    [DateLastViewed] datetime  NOT NULL,
    [Source] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Snippets'
ALTER TABLE [dbo].[Snippets]
ADD CONSTRAINT [PK_Snippets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------