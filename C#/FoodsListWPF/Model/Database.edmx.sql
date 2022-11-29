
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2020 21:01:36
-- Generated from EDMX file: C:\Users\kamil\Documents\geekbrains\C#\FoodsListWPF\Model\Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseFoods];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Foods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Foods];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Foods'
CREATE TABLE [dbo].[Foods] (
    [FoodId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL,
    [Price] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Buy] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FoodId] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [PK_Foods]
    PRIMARY KEY CLUSTERED ([FoodId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------