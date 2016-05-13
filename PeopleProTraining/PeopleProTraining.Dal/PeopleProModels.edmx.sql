
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/13/2016 08:39:08
-- Generated from EDMX file: C:\Users\turkingk\Desktop\training\PeopleProTraining\PeopleProTraining.Dal\PeopleProModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FLPeoplePro_kt];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BuildingsDepartment_Buildings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuildingsDepartment] DROP CONSTRAINT [FK_BuildingsDepartment_Buildings];
GO
IF OBJECT_ID(N'[dbo].[FK_BuildingsDepartment_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuildingsDepartment] DROP CONSTRAINT [FK_BuildingsDepartment_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_DepartmentEmployee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Buildings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Buildings];
GO
IF OBJECT_ID(N'[dbo].[BuildingsDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuildingsDepartment];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- Creating table 'Building'
CREATE TABLE [dbo].[Building] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BuildingsDepartment'
CREATE TABLE [dbo].[BuildingsDepartment] (
    [Buildings_Id] int  NOT NULL,
    [Departments_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Building'
ALTER TABLE [dbo].[Building]
ADD CONSTRAINT [PK_Building]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Buildings_Id], [Departments_Id] in table 'BuildingsDepartment'
ALTER TABLE [dbo].[BuildingsDepartment]
ADD CONSTRAINT [PK_BuildingsDepartment]
    PRIMARY KEY CLUSTERED ([Buildings_Id], [Departments_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Buildings_Id] in table 'BuildingsDepartment'
ALTER TABLE [dbo].[BuildingsDepartment]
ADD CONSTRAINT [FK_BuildingsDepartment_Buildings]
    FOREIGN KEY ([Buildings_Id])
    REFERENCES [dbo].[Building]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Departments_Id] in table 'BuildingsDepartment'
ALTER TABLE [dbo].[BuildingsDepartment]
ADD CONSTRAINT [FK_BuildingsDepartment_Department]
    FOREIGN KEY ([Departments_Id])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuildingsDepartment_Department'
CREATE INDEX [IX_FK_BuildingsDepartment_Department]
ON [dbo].[BuildingsDepartment]
    ([Departments_Id]);
GO

-- Creating foreign key on [DepartmentId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[Employees]
    ([DepartmentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------