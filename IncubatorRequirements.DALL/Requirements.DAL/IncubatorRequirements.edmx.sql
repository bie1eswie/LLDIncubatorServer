
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/14/2018 15:44:39
-- Generated from EDMX file: C:\Users\Thapelo\Documents\Visual Studio 2015\Projects\IncubatorRequirements.DALL\Requirements.DAL\IncubatorRequirements.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IncubatorRequirement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientFieldFieldSetMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FieldSetMaps] DROP CONSTRAINT [FK_ClientFieldFieldSetMap];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientFieldFieldType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientFields] DROP CONSTRAINT [FK_ClientFieldFieldType];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientTypeRequirementMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequirementMaps] DROP CONSTRAINT [FK_ClientTypeRequirementMap];
GO
IF OBJECT_ID(N'[dbo].[FK_DropdownSetDropdownSetMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DropdownSetMaps] DROP CONSTRAINT [FK_DropdownSetDropdownSetMap];
GO
IF OBJECT_ID(N'[dbo].[FK_DropdownValueDropdownSetMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DropdownSetMaps] DROP CONSTRAINT [FK_DropdownValueDropdownSetMap];
GO
IF OBJECT_ID(N'[dbo].[FK_FieldSetFieldSetGroupMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FieldSetGroupMaps] DROP CONSTRAINT [FK_FieldSetFieldSetGroupMap];
GO
IF OBJECT_ID(N'[dbo].[FK_FieldSetFieldSetMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FieldSetMaps] DROP CONSTRAINT [FK_FieldSetFieldSetMap];
GO
IF OBJECT_ID(N'[dbo].[FK_FieldSetGroupFieldSetGroupMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FieldSetGroupMaps] DROP CONSTRAINT [FK_FieldSetGroupFieldSetGroupMap];
GO
IF OBJECT_ID(N'[dbo].[FK_FieldSetGroupRequirementMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequirementMaps] DROP CONSTRAINT [FK_FieldSetGroupRequirementMap];
GO
IF OBJECT_ID(N'[dbo].[FK_RequirementRequirementMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequirementMaps] DROP CONSTRAINT [FK_RequirementRequirementMap];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Booleans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booleans];
GO
IF OBJECT_ID(N'[dbo].[CalculationMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalculationMaps];
GO
IF OBJECT_ID(N'[dbo].[Calculations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calculations];
GO
IF OBJECT_ID(N'[dbo].[ClientFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientFields];
GO
IF OBJECT_ID(N'[dbo].[ClientTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientTypes];
GO
IF OBJECT_ID(N'[dbo].[DropdownSetMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DropdownSetMaps];
GO
IF OBJECT_ID(N'[dbo].[DropdownSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DropdownSets];
GO
IF OBJECT_ID(N'[dbo].[DropdownValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DropdownValues];
GO
IF OBJECT_ID(N'[dbo].[FieldSetGroupMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FieldSetGroupMaps];
GO
IF OBJECT_ID(N'[dbo].[FieldSetGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FieldSetGroups];
GO
IF OBJECT_ID(N'[dbo].[FieldSetMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FieldSetMaps];
GO
IF OBJECT_ID(N'[dbo].[FieldSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FieldSets];
GO
IF OBJECT_ID(N'[dbo].[FieldTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FieldTypes];
GO
IF OBJECT_ID(N'[dbo].[IncubatorQuardrants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncubatorQuardrants];
GO
IF OBJECT_ID(N'[dbo].[QuardrantMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuardrantMaps];
GO
IF OBJECT_ID(N'[dbo].[RejectionReasons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RejectionReasons];
GO
IF OBJECT_ID(N'[dbo].[RequirementMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequirementMaps];
GO
IF OBJECT_ID(N'[dbo].[Requirements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requirements];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStageMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStageMaps];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStageReasons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStageReasons];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStages];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStatus];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Booleans'
CREATE TABLE [dbo].[Booleans] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'CalculationMaps'
CREATE TABLE [dbo].[CalculationMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [Parameter_Code] nvarchar(250)  NULL,
    [Parameter_Name] nvarchar(250)  NULL,
    [Parameter_ID] int  NULL,
    [Caculation_Code] nvarchar(250)  NULL,
    [Caculation_Name] nvarchar(250)  NULL,
    [Caculation_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'Calculations'
CREATE TABLE [dbo].[Calculations] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'ClientFields'
CREATE TABLE [dbo].[ClientFields] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [FieldType_Code] nvarchar(250)  NULL,
    [FieldType_Name] nvarchar(250)  NULL,
    [FieldType_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'ClientTypes'
CREATE TABLE [dbo].[ClientTypes] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'DropdownSetMaps'
CREATE TABLE [dbo].[DropdownSetMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [DropdownValue_Code] nvarchar(250)  NULL,
    [DropdownValue_Name] nvarchar(250)  NULL,
    [DropdownValue_ID] int  NULL,
    [DropdownSet_Code] nvarchar(250)  NULL,
    [DropdownSet_Name] nvarchar(250)  NULL,
    [DropdownSet_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [ScoreCard] nvarchar(100)  NULL
);
GO

-- Creating table 'DropdownSets'
CREATE TABLE [dbo].[DropdownSets] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'DropdownValues'
CREATE TABLE [dbo].[DropdownValues] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'FieldSetGroupMaps'
CREATE TABLE [dbo].[FieldSetGroupMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [FieldSet_Code] nvarchar(250)  NULL,
    [FieldSet_Name] nvarchar(250)  NULL,
    [FieldSet_ID] int  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [FieldSetOrder] nvarchar(100)  NULL
);
GO

-- Creating table 'FieldSetGroups'
CREATE TABLE [dbo].[FieldSetGroups] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'FieldSetMaps'
CREATE TABLE [dbo].[FieldSetMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [Field_Code] nvarchar(250)  NULL,
    [Field_Name] nvarchar(250)  NULL,
    [Field_ID] int  NULL,
    [DropdownSet_Code] nvarchar(250)  NULL,
    [DropdownSet_Name] nvarchar(250)  NULL,
    [DropdownSet_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [FieldSet_Code] nvarchar(250)  NULL,
    [FieldSet_Name] nvarchar(250)  NULL,
    [FieldSetID] int  NULL,
    [ToolTip] nvarchar(100)  NULL,
    [FieldOrder] nvarchar(100)  NULL,
    [IsRequired_Code] nvarchar(250)  NULL,
    [IsRequired_Name] nvarchar(250)  NULL,
    [IsRequired_ID] int  NULL,
    [Caculation_Code] nvarchar(250)  NULL,
    [Caculation_Name] nvarchar(250)  NULL,
    [Caculation_ID] int  NULL,
    [FieldScore] nvarchar(100)  NULL,
    [IsRelated_Code] nvarchar(250)  NULL,
    [IsRelated_Name] nvarchar(250)  NULL,
    [IsRelated_ID] int  NULL,
    [Length] nvarchar(100)  NULL
);
GO

-- Creating table 'FieldSets'
CREATE TABLE [dbo].[FieldSets] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [Description] nvarchar(100)  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [PrePopulate_Code] nvarchar(250)  NULL,
    [PrePopulate_Name] nvarchar(250)  NULL,
    [PrePopulate_ID] int  NULL,
    [IsCalculated_Code] nvarchar(250)  NULL,
    [IsCalculated_Name] nvarchar(250)  NULL,
    [IsCalculated_ID] int  NULL,
    [IsHidden_Code] nvarchar(250)  NULL,
    [IsHidden_Name] nvarchar(250)  NULL,
    [IsHidden_ID] int  NULL
);
GO

-- Creating table 'FieldTypes'
CREATE TABLE [dbo].[FieldTypes] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'IncubatorQuardrants'
CREATE TABLE [dbo].[IncubatorQuardrants] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'QuardrantMaps'
CREATE TABLE [dbo].[QuardrantMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [Quadrant_Code] nvarchar(250)  NULL,
    [Quadrant_Name] nvarchar(250)  NULL,
    [Quadrant_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [RequirementsTab_Code] nvarchar(250)  NULL,
    [RequirementsTab_Name] nvarchar(250)  NULL,
    [RequirementsTab_ID] int  NULL,
    [FieldSetGroupOrder] nvarchar(100)  NULL
);
GO

-- Creating table 'RejectionReasons'
CREATE TABLE [dbo].[RejectionReasons] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [Description] nvarchar(100)  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'RequirementMaps'
CREATE TABLE [dbo].[RequirementMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [ClientType_Code] nvarchar(250)  NULL,
    [ClientType_Name] nvarchar(250)  NULL,
    [ClientType_ID] int  NULL,
    [WorkItemStatus_Code] nvarchar(250)  NULL,
    [WorkItemStatus_Name] nvarchar(250)  NULL,
    [WorkItemStatus_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [RequirementsTab_Code] nvarchar(250)  NULL,
    [RequirementsTab_Name] nvarchar(250)  NULL,
    [RequirementsTab_ID] int  NULL,
    [FieldSetGroupOrder] nvarchar(100)  NULL
);
GO

-- Creating table 'Requirements'
CREATE TABLE [dbo].[Requirements] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'WorkItemStageMaps'
CREATE TABLE [dbo].[WorkItemStageMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [ActionTeam_Code] nvarchar(250)  NULL,
    [ActionTeam_Name] nvarchar(250)  NULL,
    [ActionTeam_ID] int  NULL,
    [WorkItemStage_Code] nvarchar(250)  NULL,
    [WorkItemStage_Name] nvarchar(250)  NULL,
    [WorkItemStage_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'WorkItemStageReasons'
CREATE TABLE [dbo].[WorkItemStageReasons] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [Reason_Code] nvarchar(250)  NULL,
    [Reason_Name] nvarchar(250)  NULL,
    [Reason_ID] int  NULL,
    [Stage_Code] nvarchar(250)  NULL,
    [Stage_Name] nvarchar(250)  NULL,
    [Stage_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'WorkItemStages'
CREATE TABLE [dbo].[WorkItemStages] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [UserCanEdit_Code] nvarchar(250)  NULL,
    [UserCanEdit_Name] nvarchar(250)  NULL,
    [UserCanEdit_ID] int  NULL,
    [NextSage_Code] nvarchar(250)  NULL,
    [NextSage_Name] nvarchar(250)  NULL,
    [NextSage_ID] int  NULL,
    [BussinessCanEdit_Code] nvarchar(250)  NULL,
    [BussinessCanEdit_Name] nvarchar(250)  NULL,
    [BussinessCanEdit_ID] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [HasDocuments_Code] nvarchar(250)  NULL,
    [HasDocuments_Name] nvarchar(250)  NULL,
    [HasDocuments_ID] int  NULL,
    [PreviousStage_Code] nvarchar(250)  NULL,
    [PreviousStage_Name] nvarchar(250)  NULL,
    [PreviousStage_ID] int  NULL
);
GO

-- Creating table 'WorkItemStatus'
CREATE TABLE [dbo].[WorkItemStatus] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NULL,
    [VersionName] nvarchar(50)  NULL,
    [VersionNumber] int  NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NULL,
    [EnterDateTime] datetime  NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Booleans'
ALTER TABLE [dbo].[Booleans]
ADD CONSTRAINT [PK_Booleans]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'CalculationMaps'
ALTER TABLE [dbo].[CalculationMaps]
ADD CONSTRAINT [PK_CalculationMaps]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'Calculations'
ALTER TABLE [dbo].[Calculations]
ADD CONSTRAINT [PK_Calculations]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID] in table 'ClientFields'
ALTER TABLE [dbo].[ClientFields]
ADD CONSTRAINT [PK_ClientFields]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ClientTypes'
ALTER TABLE [dbo].[ClientTypes]
ADD CONSTRAINT [PK_ClientTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownSetMaps'
ALTER TABLE [dbo].[DropdownSetMaps]
ADD CONSTRAINT [PK_DropdownSetMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownSets'
ALTER TABLE [dbo].[DropdownSets]
ADD CONSTRAINT [PK_DropdownSets]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownValues'
ALTER TABLE [dbo].[DropdownValues]
ADD CONSTRAINT [PK_DropdownValues]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetGroupMaps'
ALTER TABLE [dbo].[FieldSetGroupMaps]
ADD CONSTRAINT [PK_FieldSetGroupMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetGroups'
ALTER TABLE [dbo].[FieldSetGroups]
ADD CONSTRAINT [PK_FieldSetGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetMaps'
ALTER TABLE [dbo].[FieldSetMaps]
ADD CONSTRAINT [PK_FieldSetMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSets'
ALTER TABLE [dbo].[FieldSets]
ADD CONSTRAINT [PK_FieldSets]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldTypes'
ALTER TABLE [dbo].[FieldTypes]
ADD CONSTRAINT [PK_FieldTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'IncubatorQuardrants'
ALTER TABLE [dbo].[IncubatorQuardrants]
ADD CONSTRAINT [PK_IncubatorQuardrants]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuardrantMaps'
ALTER TABLE [dbo].[QuardrantMaps]
ADD CONSTRAINT [PK_QuardrantMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RejectionReasons'
ALTER TABLE [dbo].[RejectionReasons]
ADD CONSTRAINT [PK_RejectionReasons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RequirementMaps'
ALTER TABLE [dbo].[RequirementMaps]
ADD CONSTRAINT [PK_RequirementMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Requirements'
ALTER TABLE [dbo].[Requirements]
ADD CONSTRAINT [PK_Requirements]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStageMaps'
ALTER TABLE [dbo].[WorkItemStageMaps]
ADD CONSTRAINT [PK_WorkItemStageMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStageReasons'
ALTER TABLE [dbo].[WorkItemStageReasons]
ADD CONSTRAINT [PK_WorkItemStageReasons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStages'
ALTER TABLE [dbo].[WorkItemStages]
ADD CONSTRAINT [PK_WorkItemStages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStatus'
ALTER TABLE [dbo].[WorkItemStatus]
ADD CONSTRAINT [PK_WorkItemStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Field_ID] in table 'FieldSetMaps'
ALTER TABLE [dbo].[FieldSetMaps]
ADD CONSTRAINT [FK_ClientFieldFieldSetMap]
    FOREIGN KEY ([Field_ID])
    REFERENCES [dbo].[ClientFields]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientFieldFieldSetMap'
CREATE INDEX [IX_FK_ClientFieldFieldSetMap]
ON [dbo].[FieldSetMaps]
    ([Field_ID]);
GO

-- Creating foreign key on [FieldType_ID] in table 'ClientFields'
ALTER TABLE [dbo].[ClientFields]
ADD CONSTRAINT [FK_ClientFieldFieldType]
    FOREIGN KEY ([FieldType_ID])
    REFERENCES [dbo].[FieldTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientFieldFieldType'
CREATE INDEX [IX_FK_ClientFieldFieldType]
ON [dbo].[ClientFields]
    ([FieldType_ID]);
GO

-- Creating foreign key on [ClientType_ID] in table 'RequirementMaps'
ALTER TABLE [dbo].[RequirementMaps]
ADD CONSTRAINT [FK_ClientTypeRequirementMap]
    FOREIGN KEY ([ClientType_ID])
    REFERENCES [dbo].[ClientTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientTypeRequirementMap'
CREATE INDEX [IX_FK_ClientTypeRequirementMap]
ON [dbo].[RequirementMaps]
    ([ClientType_ID]);
GO

-- Creating foreign key on [DropdownSet_ID] in table 'DropdownSetMaps'
ALTER TABLE [dbo].[DropdownSetMaps]
ADD CONSTRAINT [FK_DropdownSetDropdownSetMap]
    FOREIGN KEY ([DropdownSet_ID])
    REFERENCES [dbo].[DropdownSets]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DropdownSetDropdownSetMap'
CREATE INDEX [IX_FK_DropdownSetDropdownSetMap]
ON [dbo].[DropdownSetMaps]
    ([DropdownSet_ID]);
GO

-- Creating foreign key on [DropdownValue_ID] in table 'DropdownSetMaps'
ALTER TABLE [dbo].[DropdownSetMaps]
ADD CONSTRAINT [FK_DropdownValueDropdownSetMap]
    FOREIGN KEY ([DropdownValue_ID])
    REFERENCES [dbo].[DropdownValues]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DropdownValueDropdownSetMap'
CREATE INDEX [IX_FK_DropdownValueDropdownSetMap]
ON [dbo].[DropdownSetMaps]
    ([DropdownValue_ID]);
GO

-- Creating foreign key on [FieldSet_ID] in table 'FieldSetGroupMaps'
ALTER TABLE [dbo].[FieldSetGroupMaps]
ADD CONSTRAINT [FK_FieldSetFieldSetGroupMap]
    FOREIGN KEY ([FieldSet_ID])
    REFERENCES [dbo].[FieldSets]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FieldSetFieldSetGroupMap'
CREATE INDEX [IX_FK_FieldSetFieldSetGroupMap]
ON [dbo].[FieldSetGroupMaps]
    ([FieldSet_ID]);
GO

-- Creating foreign key on [FieldSetGroup_ID] in table 'FieldSetGroupMaps'
ALTER TABLE [dbo].[FieldSetGroupMaps]
ADD CONSTRAINT [FK_FieldSetGroupFieldSetGroupMap]
    FOREIGN KEY ([FieldSetGroup_ID])
    REFERENCES [dbo].[FieldSetGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FieldSetGroupFieldSetGroupMap'
CREATE INDEX [IX_FK_FieldSetGroupFieldSetGroupMap]
ON [dbo].[FieldSetGroupMaps]
    ([FieldSetGroup_ID]);
GO

-- Creating foreign key on [FieldSetGroup_ID] in table 'RequirementMaps'
ALTER TABLE [dbo].[RequirementMaps]
ADD CONSTRAINT [FK_FieldSetGroupRequirementMap]
    FOREIGN KEY ([FieldSetGroup_ID])
    REFERENCES [dbo].[FieldSetGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FieldSetGroupRequirementMap'
CREATE INDEX [IX_FK_FieldSetGroupRequirementMap]
ON [dbo].[RequirementMaps]
    ([FieldSetGroup_ID]);
GO

-- Creating foreign key on [FieldSetID] in table 'FieldSetMaps'
ALTER TABLE [dbo].[FieldSetMaps]
ADD CONSTRAINT [FK_FieldSetFieldSetMap]
    FOREIGN KEY ([FieldSetID])
    REFERENCES [dbo].[FieldSets]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FieldSetFieldSetMap'
CREATE INDEX [IX_FK_FieldSetFieldSetMap]
ON [dbo].[FieldSetMaps]
    ([FieldSetID]);
GO

-- Creating foreign key on [RequirementsTab_ID] in table 'RequirementMaps'
ALTER TABLE [dbo].[RequirementMaps]
ADD CONSTRAINT [FK_RequirementRequirementMap]
    FOREIGN KEY ([RequirementsTab_ID])
    REFERENCES [dbo].[Requirements]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequirementRequirementMap'
CREATE INDEX [IX_FK_RequirementRequirementMap]
ON [dbo].[RequirementMaps]
    ([RequirementsTab_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------