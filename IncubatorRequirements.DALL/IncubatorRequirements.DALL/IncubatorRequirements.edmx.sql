
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2018 07:53:12
-- Generated from EDMX file: C:\Users\Thapelo\Documents\Visual Studio 2015\Projects\IncubatorRequirements.DALL\IncubatorRequirements.DALL\IncubatorRequirements.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Incubator];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_Boolean]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_Boolean];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_Calculation]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_Calculation];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_CalculationMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_CalculationMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_ClientType]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_ClientType];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_DropdownSet]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_DropdownSet];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_DropdownSetMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_DropdownSetMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_DropdownValue]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_DropdownValue];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_FieldSet]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_FieldSet];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_FieldSetGroup]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_FieldSetGroup];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_FieldSetGroup_Map]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_FieldSetGroup_Map];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_FieldSetMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_FieldSetMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_FieldType]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_FieldType];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_IncubatorQuardrant]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_IncubatorQuardrant];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_QuardrantMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_QuardrantMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_RejectionReason]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_RejectionReason];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_Requirement]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_Requirement];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_RequirementMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_RequirementMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_WorkItemStageMap]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_WorkItemStageMap];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_WorkItemStageReason]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_WorkItemStageReason];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_WorkItemStages]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_WorkItemStages];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[Client_WorkItemStatu]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[Client_WorkItemStatu];
GO
IF OBJECT_ID(N'[IncubatorModelStoreContainer].[ClientField]', 'U') IS NOT NULL
    DROP TABLE [IncubatorModelStoreContainer].[ClientField];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

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
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [ScoreCard] nvarchar(100)  NULL
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

-- Creating table 'FieldSets'
CREATE TABLE [dbo].[FieldSets] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [Description] nvarchar(100)  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
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

-- Creating table 'FieldSetGroups'
CREATE TABLE [dbo].[FieldSetGroups] (
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
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [FieldSet_Code] nvarchar(250)  NULL,
    [FieldSet_Name] nvarchar(250)  NULL,
    [FieldSet_ID] int  NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [FieldSetOrder] nvarchar(100)  NULL
);
GO

-- Creating table 'FieldSetMaps'
CREATE TABLE [dbo].[FieldSetMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [Field_Code] nvarchar(250)  NULL,
    [Field_Name] nvarchar(250)  NULL,
    [Field_ID] int  NULL,
    [DropdownSet_Code] nvarchar(250)  NULL,
    [DropdownSet_Name] nvarchar(250)  NULL,
    [DropdownSet_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
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

-- Creating table 'FieldTypes'
CREATE TABLE [dbo].[FieldTypes] (
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

-- Creating table 'Requirements'
CREATE TABLE [dbo].[Requirements] (
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

-- Creating table 'RequirementMaps'
CREATE TABLE [dbo].[RequirementMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [ClientType_Code] nvarchar(250)  NULL,
    [ClientType_Name] nvarchar(250)  NULL,
    [ClientType_ID] int  NULL,
    [WorkItemStatus_Code] nvarchar(250)  NULL,
    [WorkItemStatus_Name] nvarchar(250)  NULL,
    [WorkItemStatus_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [RequirementsTab_Code] nvarchar(250)  NULL,
    [RequirementsTab_Name] nvarchar(250)  NULL,
    [RequirementsTab_ID] int  NULL,
    [FieldSetGroupOrder] nvarchar(100)  NULL
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

-- Creating table 'WorkItemStages'
CREATE TABLE [dbo].[WorkItemStages] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [UserCanEdit_Code] nvarchar(250)  NULL,
    [UserCanEdit_Name] nvarchar(250)  NULL,
    [UserCanEdit_ID] int  NULL,
    [NextSage_Code] nvarchar(250)  NULL,
    [NextSage_Name] nvarchar(250)  NULL,
    [NextSage_ID] int  NULL,
    [BussinessCanEdit_Code] nvarchar(250)  NULL,
    [BussinessCanEdit_Name] nvarchar(250)  NULL,
    [BussinessCanEdit_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
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

-- Creating table 'WorkItemStageMaps'
CREATE TABLE [dbo].[WorkItemStageMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [ActionTeam_Code] nvarchar(250)  NULL,
    [ActionTeam_Name] nvarchar(250)  NULL,
    [ActionTeam_ID] int  NULL,
    [WorkItemStage_Code] nvarchar(250)  NULL,
    [WorkItemStage_Name] nvarchar(250)  NULL,
    [WorkItemStage_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'RejectionReasons'
CREATE TABLE [dbo].[RejectionReasons] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [Description] nvarchar(100)  NULL,
    [EnterDateTime] datetime  NOT NULL,
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
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [Reason_Code] nvarchar(250)  NULL,
    [Reason_Name] nvarchar(250)  NULL,
    [Reason_ID] int  NULL,
    [Stage_Code] nvarchar(250)  NULL,
    [Stage_Name] nvarchar(250)  NULL,
    [Stage_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL
);
GO

-- Creating table 'IncubatorQuardrants'
CREATE TABLE [dbo].[IncubatorQuardrants] (
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

-- Creating table 'QuardrantMaps'
CREATE TABLE [dbo].[QuardrantMaps] (
    [ID] int  NOT NULL,
    [MUID] uniqueidentifier  NOT NULL,
    [VersionName] nvarchar(50)  NOT NULL,
    [VersionNumber] int  NOT NULL,
    [VersionFlag] nvarchar(50)  NULL,
    [Name] nvarchar(250)  NULL,
    [Code] nvarchar(250)  NOT NULL,
    [ChangeTrackingMask] int  NOT NULL,
    [FieldSetGroup_Code] nvarchar(250)  NULL,
    [FieldSetGroup_Name] nvarchar(250)  NULL,
    [FieldSetGroup_ID] int  NULL,
    [Quadrant_Code] nvarchar(250)  NULL,
    [Quadrant_Name] nvarchar(250)  NULL,
    [Quadrant_ID] int  NULL,
    [EnterDateTime] datetime  NOT NULL,
    [EnterUserName] nvarchar(100)  NULL,
    [EnterVersionNumber] int  NULL,
    [LastChgDateTime] datetime  NOT NULL,
    [LastChgUserName] nvarchar(100)  NULL,
    [LastChgVersionNumber] int  NULL,
    [ValidationStatus] nvarchar(250)  NULL,
    [RequirementsTab_Code] nvarchar(250)  NULL,
    [RequirementsTab_Name] nvarchar(250)  NULL,
    [RequirementsTab_ID] int  NULL,
    [FieldSetGroupOrder] nvarchar(100)  NULL
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

-- Creating table 'WorkItemStatus'
CREATE TABLE [dbo].[WorkItemStatus] (
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ClientTypes'
ALTER TABLE [dbo].[ClientTypes]
ADD CONSTRAINT [PK_ClientTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownSets'
ALTER TABLE [dbo].[DropdownSets]
ADD CONSTRAINT [PK_DropdownSets]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownSetMaps'
ALTER TABLE [dbo].[DropdownSetMaps]
ADD CONSTRAINT [PK_DropdownSetMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DropdownValues'
ALTER TABLE [dbo].[DropdownValues]
ADD CONSTRAINT [PK_DropdownValues]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSets'
ALTER TABLE [dbo].[FieldSets]
ADD CONSTRAINT [PK_FieldSets]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetGroups'
ALTER TABLE [dbo].[FieldSetGroups]
ADD CONSTRAINT [PK_FieldSetGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetGroupMaps'
ALTER TABLE [dbo].[FieldSetGroupMaps]
ADD CONSTRAINT [PK_FieldSetGroupMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldSetMaps'
ALTER TABLE [dbo].[FieldSetMaps]
ADD CONSTRAINT [PK_FieldSetMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FieldTypes'
ALTER TABLE [dbo].[FieldTypes]
ADD CONSTRAINT [PK_FieldTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Requirements'
ALTER TABLE [dbo].[Requirements]
ADD CONSTRAINT [PK_Requirements]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RequirementMaps'
ALTER TABLE [dbo].[RequirementMaps]
ADD CONSTRAINT [PK_RequirementMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ClientFields'
ALTER TABLE [dbo].[ClientFields]
ADD CONSTRAINT [PK_ClientFields]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Booleans'
ALTER TABLE [dbo].[Booleans]
ADD CONSTRAINT [PK_Booleans]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStages'
ALTER TABLE [dbo].[WorkItemStages]
ADD CONSTRAINT [PK_WorkItemStages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStageMaps'
ALTER TABLE [dbo].[WorkItemStageMaps]
ADD CONSTRAINT [PK_WorkItemStageMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RejectionReasons'
ALTER TABLE [dbo].[RejectionReasons]
ADD CONSTRAINT [PK_RejectionReasons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStageReasons'
ALTER TABLE [dbo].[WorkItemStageReasons]
ADD CONSTRAINT [PK_WorkItemStageReasons]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'IncubatorQuardrants'
ALTER TABLE [dbo].[IncubatorQuardrants]
ADD CONSTRAINT [PK_IncubatorQuardrants]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'QuardrantMaps'
ALTER TABLE [dbo].[QuardrantMaps]
ADD CONSTRAINT [PK_QuardrantMaps]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'Calculations'
ALTER TABLE [dbo].[Calculations]
ADD CONSTRAINT [PK_Calculations]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] in table 'CalculationMaps'
ALTER TABLE [dbo].[CalculationMaps]
ADD CONSTRAINT [PK_CalculationMaps]
    PRIMARY KEY CLUSTERED ([ID], [MUID], [VersionName], [VersionNumber], [Code], [ChangeTrackingMask], [EnterDateTime], [LastChgDateTime] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStatus'
ALTER TABLE [dbo].[WorkItemStatus]
ADD CONSTRAINT [PK_WorkItemStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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