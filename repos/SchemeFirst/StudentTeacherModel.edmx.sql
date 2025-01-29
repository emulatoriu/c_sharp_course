
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2023 18:57:23
-- Generated from EDMX file: C:\Users\emula\source\repos\SchemeFirst\StudentTeacherModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentTeacherScheme];
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

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TeacherSet'
CREATE TABLE [dbo].[TeacherSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'StudentTeacherSet'
CREATE TABLE [dbo].[StudentTeacherSet] (
    [StudentID] int  NOT NULL,
    [TeacherID] int  NOT NULL
);
GO

-- Creating table 'StudentStudentTeacher'
CREATE TABLE [dbo].[StudentStudentTeacher] (
    [Student_Id] int  NOT NULL,
    [StudentTeacher_StudentID] int  NOT NULL,
    [StudentTeacher_TeacherID] int  NOT NULL
);
GO

-- Creating table 'TeacherStudentTeacher'
CREATE TABLE [dbo].[TeacherStudentTeacher] (
    [Teacher_Id] int  NOT NULL,
    [StudentTeacher_StudentID] int  NOT NULL,
    [StudentTeacher_TeacherID] int  NOT NULL
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

-- Creating primary key on [Id] in table 'TeacherSet'
ALTER TABLE [dbo].[TeacherSet]
ADD CONSTRAINT [PK_TeacherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StudentID], [TeacherID] in table 'StudentTeacherSet'
ALTER TABLE [dbo].[StudentTeacherSet]
ADD CONSTRAINT [PK_StudentTeacherSet]
    PRIMARY KEY CLUSTERED ([StudentID], [TeacherID] ASC);
GO

-- Creating primary key on [Student_Id], [StudentTeacher_StudentID], [StudentTeacher_TeacherID] in table 'StudentStudentTeacher'
ALTER TABLE [dbo].[StudentStudentTeacher]
ADD CONSTRAINT [PK_StudentStudentTeacher]
    PRIMARY KEY CLUSTERED ([Student_Id], [StudentTeacher_StudentID], [StudentTeacher_TeacherID] ASC);
GO

-- Creating primary key on [Teacher_Id], [StudentTeacher_StudentID], [StudentTeacher_TeacherID] in table 'TeacherStudentTeacher'
ALTER TABLE [dbo].[TeacherStudentTeacher]
ADD CONSTRAINT [PK_TeacherStudentTeacher]
    PRIMARY KEY CLUSTERED ([Teacher_Id], [StudentTeacher_StudentID], [StudentTeacher_TeacherID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Student_Id] in table 'StudentStudentTeacher'
ALTER TABLE [dbo].[StudentStudentTeacher]
ADD CONSTRAINT [FK_StudentStudentTeacher_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StudentTeacher_StudentID], [StudentTeacher_TeacherID] in table 'StudentStudentTeacher'
ALTER TABLE [dbo].[StudentStudentTeacher]
ADD CONSTRAINT [FK_StudentStudentTeacher_StudentTeacher]
    FOREIGN KEY ([StudentTeacher_StudentID], [StudentTeacher_TeacherID])
    REFERENCES [dbo].[StudentTeacherSet]
        ([StudentID], [TeacherID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudentTeacher_StudentTeacher'
CREATE INDEX [IX_FK_StudentStudentTeacher_StudentTeacher]
ON [dbo].[StudentStudentTeacher]
    ([StudentTeacher_StudentID], [StudentTeacher_TeacherID]);
GO

-- Creating foreign key on [Teacher_Id] in table 'TeacherStudentTeacher'
ALTER TABLE [dbo].[TeacherStudentTeacher]
ADD CONSTRAINT [FK_TeacherStudentTeacher_Teacher]
    FOREIGN KEY ([Teacher_Id])
    REFERENCES [dbo].[TeacherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StudentTeacher_StudentID], [StudentTeacher_TeacherID] in table 'TeacherStudentTeacher'
ALTER TABLE [dbo].[TeacherStudentTeacher]
ADD CONSTRAINT [FK_TeacherStudentTeacher_StudentTeacher]
    FOREIGN KEY ([StudentTeacher_StudentID], [StudentTeacher_TeacherID])
    REFERENCES [dbo].[StudentTeacherSet]
        ([StudentID], [TeacherID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherStudentTeacher_StudentTeacher'
CREATE INDEX [IX_FK_TeacherStudentTeacher_StudentTeacher]
ON [dbo].[TeacherStudentTeacher]
    ([StudentTeacher_StudentID], [StudentTeacher_TeacherID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------