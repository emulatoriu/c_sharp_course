
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2022 10:01:32
-- Generated from EDMX file: C:\Users\z001ms7m\source\repos\EF_ModelFirstSample\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_KursStudent_Kurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KursStudent] DROP CONSTRAINT [FK_KursStudent_Kurs];
GO
IF OBJECT_ID(N'[dbo].[FK_KursStudent_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KursStudent] DROP CONSTRAINT [FK_KursStudent_Student];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO
IF OBJECT_ID(N'[dbo].[KursSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KursSet];
GO
IF OBJECT_ID(N'[dbo].[KursStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KursStudent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Nachname] nvarchar(max)  NOT NULL,
    [Alter] smallint  NOT NULL,
    [Matrikelnummer] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KursSet'
CREATE TABLE [dbo].[KursSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KursStudent'
CREATE TABLE [dbo].[KursStudent] (
    [Kurs_Id] int  NOT NULL,
    [Student_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KursSet'
ALTER TABLE [dbo].[KursSet]
ADD CONSTRAINT [PK_KursSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Kurs_Id], [Student_Id] in table 'KursStudent'
ALTER TABLE [dbo].[KursStudent]
ADD CONSTRAINT [PK_KursStudent]
    PRIMARY KEY CLUSTERED ([Kurs_Id], [Student_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kurs_Id] in table 'KursStudent'
ALTER TABLE [dbo].[KursStudent]
ADD CONSTRAINT [FK_KursStudent_Kurs]
    FOREIGN KEY ([Kurs_Id])
    REFERENCES [dbo].[KursSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Student_Id] in table 'KursStudent'
ALTER TABLE [dbo].[KursStudent]
ADD CONSTRAINT [FK_KursStudent_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KursStudent_Student'
CREATE INDEX [IX_FK_KursStudent_Student]
ON [dbo].[KursStudent]
    ([Student_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------