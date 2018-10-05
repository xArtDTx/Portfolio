
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/24/2018 07:45:22
-- Generated from EDMX file: C:\Users\artge\source\repos\HwWpfMailSender\EfHwApp\DataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Accounting];
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

-- Creating table 'FinancialAccountingSet'
CREATE TABLE [dbo].[FinancialAccountingSet] (
    [FinancialAccountingId] int IDENTITY(1,1) NOT NULL,
    [Profit] int  NOT NULL,
    [Costs] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FinancialAccountingId] in table 'FinancialAccountingSet'
ALTER TABLE [dbo].[FinancialAccountingSet]
ADD CONSTRAINT [PK_FinancialAccountingSet]
    PRIMARY KEY CLUSTERED ([FinancialAccountingId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------