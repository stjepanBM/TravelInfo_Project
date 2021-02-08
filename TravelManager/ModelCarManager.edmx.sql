
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/13/2019 23:11:26
-- Generated from EDMX file: D:\Algebra\5.semestar\PPPK\Projekt\MVC\TravelInfo\TravelManager\ModelCarManager.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CityState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_CityState];
GO
IF OBJECT_ID(N'[dbo].[FK_Service]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Service];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TravelInfo] DROP CONSTRAINT [FK_TravelCar];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelDriver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TravelInfo] DROP CONSTRAINT [FK_TravelDriver];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelInfoRoute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Route] DROP CONSTRAINT [FK_TravelInfoRoute];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelStartCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TravelInfo] DROP CONSTRAINT [FK_TravelStartCity];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelStopCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TravelInfo] DROP CONSTRAINT [FK_TravelStopCity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Driver]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Driver];
GO
IF OBJECT_ID(N'[dbo].[Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item];
GO
IF OBJECT_ID(N'[dbo].[Route]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Route];
GO
IF OBJECT_ID(N'[dbo].[Service]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Service];
GO
IF OBJECT_ID(N'[dbo].[State]', 'U') IS NOT NULL
    DROP TABLE [dbo].[State];
GO
IF OBJECT_ID(N'[dbo].[TravelInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TravelInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [IDCar] int IDENTITY(1,1) NOT NULL,
    [CarType] nvarchar(50)  NULL,
    [Brand] nvarchar(50)  NULL,
    [YearOfMaking] int  NULL,
    [Mileage] int  NULL,
    [CarReserved] bit  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [IDCity] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(50)  NULL,
    [StateID] int  NULL
);
GO

-- Creating table 'Drivers'
CREATE TABLE [dbo].[Drivers] (
    [IDDriver] int IDENTITY(1,1) NOT NULL,
    [DriverName] nvarchar(50)  NULL,
    [DriverSurname] nvarchar(50)  NULL,
    [Telephone] nvarchar(50)  NULL,
    [LicenceNumber] int  NULL
);
GO

-- Creating table 'Routes'
CREATE TABLE [dbo].[Routes] (
    [IDRoute] int IDENTITY(1,1) NOT NULL,
    [Time] nvarchar(10)  NULL,
    [CoordinatesALength] nvarchar(50)  NULL,
    [CoordinatesAWidth] nvarchar(50)  NULL,
    [CoordinatesBLength] nvarchar(50)  NULL,
    [CoordinatesBWidth] nvarchar(50)  NULL,
    [TravelLength] int  NULL,
    [AverageSpeed] int  NULL,
    [FuelConsumption] int  NULL,
    [TravelInfoID] int  NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [IDState] int IDENTITY(1,1) NOT NULL,
    [StateName] nvarchar(50)  NULL
);
GO

-- Creating table 'TravelInfoes'
CREATE TABLE [dbo].[TravelInfoes] (
    [IDTravelInfo] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(20)  NULL,
    [DriverID] int  NULL,
    [TravelLength] float  NULL,
    [DaysExpected] int  NULL,
    [StartCity] int  NULL,
    [StopCity] int  NULL,
    [CarID] int  NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [IDItem] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Price] int  NULL,
    [Service] int  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [IDService] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [DateOfService] datetime  NULL,
    [Price] int  NULL,
    [CarIDCar] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDCar] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([IDCar] ASC);
GO

-- Creating primary key on [IDCity] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([IDCity] ASC);
GO

-- Creating primary key on [IDDriver] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [PK_Drivers]
    PRIMARY KEY CLUSTERED ([IDDriver] ASC);
GO

-- Creating primary key on [IDRoute] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [PK_Routes]
    PRIMARY KEY CLUSTERED ([IDRoute] ASC);
GO

-- Creating primary key on [IDState] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([IDState] ASC);
GO

-- Creating primary key on [IDTravelInfo] in table 'TravelInfoes'
ALTER TABLE [dbo].[TravelInfoes]
ADD CONSTRAINT [PK_TravelInfoes]
    PRIMARY KEY CLUSTERED ([IDTravelInfo] ASC);
GO

-- Creating primary key on [IDItem] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([IDItem] ASC);
GO

-- Creating primary key on [IDService] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([IDService] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarID] in table 'TravelInfoes'
ALTER TABLE [dbo].[TravelInfoes]
ADD CONSTRAINT [FK_TravelCar]
    FOREIGN KEY ([CarID])
    REFERENCES [dbo].[Cars]
        ([IDCar])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelCar'
CREATE INDEX [IX_FK_TravelCar]
ON [dbo].[TravelInfoes]
    ([CarID]);
GO

-- Creating foreign key on [StateID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_CityState]
    FOREIGN KEY ([StateID])
    REFERENCES [dbo].[States]
        ([IDState])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityState'
CREATE INDEX [IX_FK_CityState]
ON [dbo].[Cities]
    ([StateID]);
GO

-- Creating foreign key on [StartCity] in table 'TravelInfoes'
ALTER TABLE [dbo].[TravelInfoes]
ADD CONSTRAINT [FK_TravelStartCity]
    FOREIGN KEY ([StartCity])
    REFERENCES [dbo].[Cities]
        ([IDCity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelStartCity'
CREATE INDEX [IX_FK_TravelStartCity]
ON [dbo].[TravelInfoes]
    ([StartCity]);
GO

-- Creating foreign key on [StopCity] in table 'TravelInfoes'
ALTER TABLE [dbo].[TravelInfoes]
ADD CONSTRAINT [FK_TravelStopCity]
    FOREIGN KEY ([StopCity])
    REFERENCES [dbo].[Cities]
        ([IDCity])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelStopCity'
CREATE INDEX [IX_FK_TravelStopCity]
ON [dbo].[TravelInfoes]
    ([StopCity]);
GO

-- Creating foreign key on [DriverID] in table 'TravelInfoes'
ALTER TABLE [dbo].[TravelInfoes]
ADD CONSTRAINT [FK_TravelDriver]
    FOREIGN KEY ([DriverID])
    REFERENCES [dbo].[Drivers]
        ([IDDriver])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelDriver'
CREATE INDEX [IX_FK_TravelDriver]
ON [dbo].[TravelInfoes]
    ([DriverID]);
GO

-- Creating foreign key on [TravelInfoID] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_TravelInfoRoute]
    FOREIGN KEY ([TravelInfoID])
    REFERENCES [dbo].[TravelInfoes]
        ([IDTravelInfo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelInfoRoute'
CREATE INDEX [IX_FK_TravelInfoRoute]
ON [dbo].[Routes]
    ([TravelInfoID]);
GO

-- Creating foreign key on [Service] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Service]
    FOREIGN KEY ([Service])
    REFERENCES [dbo].[Services]
        ([IDService])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Service'
CREATE INDEX [IX_FK_Service]
ON [dbo].[Items]
    ([Service]);
GO

-- Creating foreign key on [CarIDCar] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_CarService]
    FOREIGN KEY ([CarIDCar])
    REFERENCES [dbo].[Cars]
        ([IDCar])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarService'
CREATE INDEX [IX_FK_CarService]
ON [dbo].[Services]
    ([CarIDCar]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------