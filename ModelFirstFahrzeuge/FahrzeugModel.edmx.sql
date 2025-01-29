
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2022 20:19:27
-- Generated from EDMX file: C:\Users\z001ms7m\source\repos\ModelFirstFahrzeuge\FahrzeugModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TableReservation];
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

-- Creating table 'FahrzeugeSet'
CREATE TABLE [dbo].[FahrzeugeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Marke] int  NOT NULL,
    [Erstzulassung] datetime  NOT NULL,
    [PS] smallint  NOT NULL,
    [Farbe] nvarchar(max)  NOT NULL,
    [Marke1_Id] int  NOT NULL
);
GO

-- Creating table 'MarkeSet'
CREATE TABLE [dbo].[MarkeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FMarke] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FahrzeugeSet'
ALTER TABLE [dbo].[FahrzeugeSet]
ADD CONSTRAINT [PK_FahrzeugeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarkeSet'
ALTER TABLE [dbo].[MarkeSet]
ADD CONSTRAINT [PK_MarkeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Marke1_Id] in table 'FahrzeugeSet'
ALTER TABLE [dbo].[FahrzeugeSet]
ADD CONSTRAINT [FK_FahrzeugeMarke]
    FOREIGN KEY ([Marke1_Id])
    REFERENCES [dbo].[MarkeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FahrzeugeMarke'
CREATE INDEX [IX_FK_FahrzeugeMarke]
ON [dbo].[FahrzeugeSet]
    ([Marke1_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------