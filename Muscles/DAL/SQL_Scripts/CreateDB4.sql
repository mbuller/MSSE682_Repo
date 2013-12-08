
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2013 18:47:43
-- Generated from EDMX file: C:\Users\mbuller\Documents\GitHub\MSSE682_Repo\Muscles\DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bullerMuscles];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Tickets_dbo_States_TicketState_StateId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_dbo_Tickets_dbo_States_TicketState_StateId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Tickets_dbo_Users_Owner_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_dbo_Tickets_dbo_Users_Owner_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Tickets_dbo_Users_Submitter_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_dbo_Tickets_dbo_Users_Submitter_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [TicketId] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(max)  NULL,
    [Headline] varchar(255)  NULL,
    [Notes] varchar(max)  NULL,
    [Owner_UserId] int  NULL,
    [Submitter_UserId] int  NULL,
    [TicketState_StateId] int  NULL,
    [TicketOwnerUserName] varchar(50)  NULL,
    [TicketSubmitterUserName] varchar(50)  NULL,
    [TicketStateName] varchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50) NOT NULL,
    [Password] varchar(50) NOT NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [StateId] int IDENTITY(1,1) NOT NULL,
    [StateName] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TicketId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([TicketId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [StateId] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([StateId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Owner_UserId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_dbo_Tickets_dbo_Users_Owner_UserId]
    FOREIGN KEY ([Owner_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Tickets_dbo_Users_Owner_UserId'
CREATE INDEX [IX_FK_dbo_Tickets_dbo_Users_Owner_UserId]
ON [dbo].[Tickets]
    ([Owner_UserId]);
GO

-- Creating foreign key on [Submitter_UserId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_dbo_Tickets_dbo_Users_Submitter_UserId]
    FOREIGN KEY ([Submitter_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Tickets_dbo_Users_Submitter_UserId'
CREATE INDEX [IX_FK_dbo_Tickets_dbo_Users_Submitter_UserId]
ON [dbo].[Tickets]
    ([Submitter_UserId]);
GO

-- Creating foreign key on [TicketState_StateId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_dbo_Tickets_dbo_States_TicketState_StateId]
    FOREIGN KEY ([TicketState_StateId])
    REFERENCES [dbo].[States]
        ([StateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Tickets_dbo_States_TicketState_StateId'
CREATE INDEX [IX_FK_dbo_Tickets_dbo_States_TicketState_StateId]
ON [dbo].[Tickets]
    ([TicketState_StateId]);
GO

INSERT INTO States (StateName)
VALUES ('Submitted');

INSERT INTO States (StateName)
VALUES ('Assigned');

INSERT INTO States (StateName)
VALUES ('Need_Info');

INSERT INTO States (StateName)
VALUES ('Duplicate');

INSERT INTO States (StateName)
VALUES ('Resolved');

INSERT INTO States (StateName)
VALUES ('Rejected');
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------