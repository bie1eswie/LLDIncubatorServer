
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2018 11:30:42
-- Generated from EDMX file: C:\Users\Thapelo\Documents\Visual Studio 2015\Projects\IncubatorRequirements.DALL\Sefate.Incubator.WorkItem.DAL\WorkItemEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IncubatorClients];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Clients_ClientTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_Clients_ClientTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_WorkItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_WorkItem];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupRole_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupRoles] DROP CONSTRAINT [FK_GroupRole_Groups];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupRole_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupRoles] DROP CONSTRAINT [FK_GroupRole_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_VarificationNumbers_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VarificationNumbers] DROP CONSTRAINT [FK_VarificationNumbers_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkItem_Clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkItems] DROP CONSTRAINT [FK_WorkItem_Clients];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkItemField_WorkItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkItemFields] DROP CONSTRAINT [FK_WorkItemField_WorkItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[ClientTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientTypes];
GO
IF OBJECT_ID(N'[dbo].[CommentPriorities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentPriorities];
GO
IF OBJECT_ID(N'[dbo].[CommentRecomendations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentRecomendations];
GO
IF OBJECT_ID(N'[dbo].[CompanyUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyUsers];
GO
IF OBJECT_ID(N'[dbo].[ComponentChangeTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComponentChangeTypes];
GO
IF OBJECT_ID(N'[dbo].[DocumentReviewStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentReviewStatus];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[DocumentStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentStatus];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[EventGuests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventGuests];
GO
IF OBJECT_ID(N'[dbo].[EventInvitations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventInvitations];
GO
IF OBJECT_ID(N'[dbo].[GroupRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupRoles];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[IncubationStages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncubationStages];
GO
IF OBJECT_ID(N'[dbo].[IncubatorEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncubatorEvents];
GO
IF OBJECT_ID(N'[dbo].[IncubatorQuardrants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncubatorQuardrants];
GO
IF OBJECT_ID(N'[dbo].[IncubatorQuarters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncubatorQuarters];
GO
IF OBJECT_ID(N'[dbo].[InterventionReportFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterventionReportFields];
GO
IF OBJECT_ID(N'[dbo].[InterventionReports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterventionReports];
GO
IF OBJECT_ID(N'[dbo].[InterventionReportTemplates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterventionReportTemplates];
GO
IF OBJECT_ID(N'[dbo].[Milestones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Milestones];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Stages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stages];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[VarificationNumbers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VarificationNumbers];
GO
IF OBJECT_ID(N'[dbo].[WorkItemDocumentStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemDocumentStatus];
GO
IF OBJECT_ID(N'[dbo].[WorkItemFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemFields];
GO
IF OBJECT_ID(N'[dbo].[WorkItemIncubationComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemIncubationComments];
GO
IF OBJECT_ID(N'[dbo].[WorkItemIncubationStages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemIncubationStages];
GO
IF OBJECT_ID(N'[dbo].[WorkItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItems];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStages];
GO
IF OBJECT_ID(N'[dbo].[WorkItemStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemStatus];
GO
IF OBJECT_ID(N'[dbo].[WorkItemTimeLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkItemTimeLines];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ClientID] int IDENTITY(1,1) NOT NULL,
    [ClientTypeID] int  NULL,
    [ClientName] varchar(250)  NULL,
    [RegistrationNumber] varchar(50)  NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'ClientTypes'
CREATE TABLE [dbo].[ClientTypes] (
    [ClientTypeID] int IDENTITY(1,1) NOT NULL,
    [Type] varchar(250)  NULL,
    [ClientTypeCode] varchar(50)  NULL
);
GO

-- Creating table 'CompanyUsers'
CREATE TABLE [dbo].[CompanyUsers] (
    [CompanyUserID] int  IDENTITY(1,1) NOT NULL,
    [ClientID] int  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'ComponentChangeTypes'
CREATE TABLE [dbo].[ComponentChangeTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ChangeType] nchar(10)  NULL,
    [ChangedBy] int  NULL,
    [ChangedDate] datetime  NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DocumentName] varchar(50)  NULL,
    [DocumentType] varchar(50)  NULL,
    [Content] varbinary(max)  NULL,
    [ContentType] varchar(250)  NULL,
    [WorkItemID] int  NULL,
    [ComponentRef] uniqueidentifier  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [FieldMapCode] varchar(50)  NULL,
    [Extension] varchar(50)  NOT NULL,
    [URL] varchar(250)  NOT NULL,
    [StatusID] int  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Recipients] varchar(250)  NULL,
    [Body] varchar(250)  NULL
);
GO

-- Creating table 'GroupRoles'
CREATE TABLE [dbo].[GroupRoles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupID] int  NULL,
    [Role] int  NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleType] int  NULL,
    [RoleText] varchar(50)  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [RoleID] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(250)  NULL,
    [Password] varchar(250)  NULL,
    [EmailAddress] varchar(250)  NULL,
    [UserLocked] bit  NULL,
    [Salt] varchar(250)  NULL,
    [DateCreated] datetime  NULL,
    [Fullname] varchar(250)  NULL,
    [Surname] varchar(250)  NULL,
    [Phone] varchar(50)  NULL,
    [GroupID] int  NULL
);
GO

-- Creating table 'WorkItemFields'
CREATE TABLE [dbo].[WorkItemFields] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WorkItemID] int  NULL,
    [FieldCode] varchar(50)  NULL,
    [FieldValue] varchar(250)  NULL,
    [FieldSetCode] varchar(50)  NULL,
    [MapCode] varchar(50)  NULL,
    [ComponentRef] uniqueidentifier  NOT NULL,
    [WorkItemQuarterID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [IsRelated] bit  NULL,
    [InterventionReportID] int  NULL,
    [SetNumber] int  NULL
);
GO

-- Creating table 'WorkItemStatus'
CREATE TABLE [dbo].[WorkItemStatus] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Status] varchar(50)  NULL,
    [SatusCode] varchar(50)  NOT NULL
);
GO

-- Creating table 'WorkItems'
CREATE TABLE [dbo].[WorkItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClientID] int  NULL,
    [StatusID] int  NULL,
    [CreatedBy] varchar(250)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedBy] varchar(250)  NULL,
    [ModifiedDate] datetime  NULL,
    [WorkItemQuardrantID] int  NULL,
    [IsChecked] bit  NULL
);
GO

-- Creating table 'WorkItemStages'
CREATE TABLE [dbo].[WorkItemStages] (
    [WorkItemStageID] int IDENTITY(1,1)  NOT NULL,
    [StageID] int  NULL,
    [WorkItemID] int  NULL
);
GO

-- Creating table 'Stages'
CREATE TABLE [dbo].[Stages] (
    [StageID] int IDENTITY(1,1) NOT NULL,
    [StageText] varchar(50)  NULL,
    [StageCode] varchar(50)  NULL
);
GO

-- Creating table 'IncubatorQuardrants'
CREATE TABLE [dbo].[IncubatorQuardrants] (
    [IncubatorQuardrantID] int  IDENTITY(1,1) NOT NULL,
    [IncubatorQuardrantText] varchar(50)  NULL,
    [IncubatorQuardrantCode] varchar(50)  NULL,
    [ScoreCardValue] int  NULL
);
GO

-- Creating table 'Milestones'
CREATE TABLE [dbo].[Milestones] (
    [ID] int IDENTITY(1,1)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [Description] varchar(250)  NULL,
    [QuarterID] int  NULL,
    [ShortDescription] varchar(150)  NULL
);
GO

-- Creating table 'IncubatorQuarters'
CREATE TABLE [dbo].[IncubatorQuarters] (
    [Quarder] varchar(50)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [WorkItemID] int  NULL,
    [IncubatorQuardrantID] int  NULL,
    [IncubatorQuarterID] int IDENTITY(1,1) NOT NULL,
    [ScoreCardValue] int  NULL
);
GO

-- Creating table 'IncubationStages'
CREATE TABLE [dbo].[IncubationStages] (
    [IncubationStageID] int IDENTITY(1,1) NOT NULL,
    [IncubationStageText] varchar(50)  NULL
);
GO

-- Creating table 'WorkItemIncubationComments'
CREATE TABLE [dbo].[WorkItemIncubationComments] (
    [ID] int IDENTITY(1,1)  NOT NULL,
    [CommentText] varchar(max)  NULL,
    [CreatedDateTime] datetime  NULL,
    [WorkItemID] int  NULL,
    [PriorityID] int  NULL,
    [ShortDescription] varchar(max)  NULL,
    [CreatedBy] int  NULL
);
GO

-- Creating table 'WorkItemIncubationStages'
CREATE TABLE [dbo].[WorkItemIncubationStages] (
    [WorkItemID] int  NULL,
    [IncubationSageID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CommentPriorities'
CREATE TABLE [dbo].[CommentPriorities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Priority] varchar(50)  NULL
);
GO

-- Creating table 'EventInvitations'
CREATE TABLE [dbo].[EventInvitations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClientID] int  NULL,
    [EventID] int  NULL
);
GO

-- Creating table 'IncubatorEvents'
CREATE TABLE [dbo].[IncubatorEvents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EventType] int  NULL,
    [EventDescription] varchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'WorkItemTimeLines'
CREATE TABLE [dbo].[WorkItemTimeLines] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IncubationStageID] int  NULL,
    [WorkItemID] int  NULL,
    [CreatedDate] datetime  NULL,
    [WorkItemStageID] int IDENTITY(1,1) NOT NULL,
    [CreatedBy] int  NULL
);
GO

-- Creating table 'EventGuests'
CREATE TABLE [dbo].[EventGuests] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GuestName] int  NULL,
    [Description] varchar(max)  NULL,
    [EventID] int  NULL
);
GO

-- Creating table 'VarificationNumbers'
CREATE TABLE [dbo].[VarificationNumbers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Number] varchar(50)  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'DocumentReviewStatus'
CREATE TABLE [dbo].[DocumentReviewStatus] (
    [DocumentReview] varchar(50)  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'DocumentStatus'
CREATE TABLE [dbo].[DocumentStatus] (
    [StatusID] int  NULL,
    [DocumentID] int  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'WorkItemDocumentStatus'
CREATE TABLE [dbo].[WorkItemDocumentStatus] (
    [WorkItemID] int  NULL,
    [StatusID] int  NULL,
    [StageID] int  NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CommentRecomendations'
CREATE TABLE [dbo].[CommentRecomendations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CommentID] int  NULL,
    [Response] varchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedBy] int  NULL
);
GO

-- Creating table 'InterventionReportTemplates'
CREATE TABLE [dbo].[InterventionReportTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TemplateContent] varbinary(max)  NULL,
    [Verssion] float  NULL,
    [Name] varchar(50)  NULL
);
GO

-- Creating table 'InterventionReports'
CREATE TABLE [dbo].[InterventionReports] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(250)  NULL,
    [ClientID] int  NULL
);
GO

-- Creating table 'InterventionReportFields'
CREATE TABLE [dbo].[InterventionReportFields] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [InterventionReportID] int  NULL,
    [SetNumber] int  NULL,
    [FieldValue] varchar(max)  NULL,
    [FieldCode] varchar(50)  NULL,
    [MapCode] varchar(50)  NULL,
    [WorkItemFieldCode] varchar(50)  NULL,
    [IssueID] uniqueidentifier  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ClientID] ASC);
GO

-- Creating primary key on [ClientTypeID] in table 'ClientTypes'
ALTER TABLE [dbo].[ClientTypes]
ADD CONSTRAINT [PK_ClientTypes]
    PRIMARY KEY CLUSTERED ([ClientTypeID] ASC);
GO

-- Creating primary key on [CompanyUserID] in table 'CompanyUsers'
ALTER TABLE [dbo].[CompanyUsers]
ADD CONSTRAINT [PK_CompanyUsers]
    PRIMARY KEY CLUSTERED ([CompanyUserID] ASC);
GO

-- Creating primary key on [ID] in table 'ComponentChangeTypes'
ALTER TABLE [dbo].[ComponentChangeTypes]
ADD CONSTRAINT [PK_ComponentChangeTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupRoles'
ALTER TABLE [dbo].[GroupRoles]
ADD CONSTRAINT [PK_GroupRoles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemFields'
ALTER TABLE [dbo].[WorkItemFields]
ADD CONSTRAINT [PK_WorkItemFields]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemStatus'
ALTER TABLE [dbo].[WorkItemStatus]
ADD CONSTRAINT [PK_WorkItemStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItems'
ALTER TABLE [dbo].[WorkItems]
ADD CONSTRAINT [PK_WorkItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [WorkItemStageID] in table 'WorkItemStages'
ALTER TABLE [dbo].[WorkItemStages]
ADD CONSTRAINT [PK_WorkItemStages]
    PRIMARY KEY CLUSTERED ([WorkItemStageID] ASC);
GO

-- Creating primary key on [StageID] in table 'Stages'
ALTER TABLE [dbo].[Stages]
ADD CONSTRAINT [PK_Stages]
    PRIMARY KEY CLUSTERED ([StageID] ASC);
GO

-- Creating primary key on [IncubatorQuardrantID] in table 'IncubatorQuardrants'
ALTER TABLE [dbo].[IncubatorQuardrants]
ADD CONSTRAINT [PK_IncubatorQuardrants]
    PRIMARY KEY CLUSTERED ([IncubatorQuardrantID] ASC);
GO

-- Creating primary key on [ID] in table 'Milestones'
ALTER TABLE [dbo].[Milestones]
ADD CONSTRAINT [PK_Milestones]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [IncubatorQuarterID] in table 'IncubatorQuarters'
ALTER TABLE [dbo].[IncubatorQuarters]
ADD CONSTRAINT [PK_IncubatorQuarters]
    PRIMARY KEY CLUSTERED ([IncubatorQuarterID] ASC);
GO

-- Creating primary key on [IncubationStageID] in table 'IncubationStages'
ALTER TABLE [dbo].[IncubationStages]
ADD CONSTRAINT [PK_IncubationStages]
    PRIMARY KEY CLUSTERED ([IncubationStageID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemIncubationComments'
ALTER TABLE [dbo].[WorkItemIncubationComments]
ADD CONSTRAINT [PK_WorkItemIncubationComments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemIncubationStages'
ALTER TABLE [dbo].[WorkItemIncubationStages]
ADD CONSTRAINT [PK_WorkItemIncubationStages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CommentPriorities'
ALTER TABLE [dbo].[CommentPriorities]
ADD CONSTRAINT [PK_CommentPriorities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EventInvitations'
ALTER TABLE [dbo].[EventInvitations]
ADD CONSTRAINT [PK_EventInvitations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'IncubatorEvents'
ALTER TABLE [dbo].[IncubatorEvents]
ADD CONSTRAINT [PK_IncubatorEvents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemTimeLines'
ALTER TABLE [dbo].[WorkItemTimeLines]
ADD CONSTRAINT [PK_WorkItemTimeLines]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EventGuests'
ALTER TABLE [dbo].[EventGuests]
ADD CONSTRAINT [PK_EventGuests]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VarificationNumbers'
ALTER TABLE [dbo].[VarificationNumbers]
ADD CONSTRAINT [PK_VarificationNumbers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentReviewStatus'
ALTER TABLE [dbo].[DocumentReviewStatus]
ADD CONSTRAINT [PK_DocumentReviewStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentStatus'
ALTER TABLE [dbo].[DocumentStatus]
ADD CONSTRAINT [PK_DocumentStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkItemDocumentStatus'
ALTER TABLE [dbo].[WorkItemDocumentStatus]
ADD CONSTRAINT [PK_WorkItemDocumentStatus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CommentRecomendations'
ALTER TABLE [dbo].[CommentRecomendations]
ADD CONSTRAINT [PK_CommentRecomendations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InterventionReportTemplates'
ALTER TABLE [dbo].[InterventionReportTemplates]
ADD CONSTRAINT [PK_InterventionReportTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InterventionReports'
ALTER TABLE [dbo].[InterventionReports]
ADD CONSTRAINT [PK_InterventionReports]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'InterventionReportFields'
ALTER TABLE [dbo].[InterventionReportFields]
ADD CONSTRAINT [PK_InterventionReportFields]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientTypeID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Clients_ClientTypes]
    FOREIGN KEY ([ClientTypeID])
    REFERENCES [dbo].[ClientTypes]
        ([ClientTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clients_ClientTypes'
CREATE INDEX [IX_FK_Clients_ClientTypes]
ON [dbo].[Clients]
    ([ClientTypeID]);
GO

-- Creating foreign key on [GroupID] in table 'GroupRoles'
ALTER TABLE [dbo].[GroupRoles]
ADD CONSTRAINT [FK_GroupRole_Groups]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[Groups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupRole_Groups'
CREATE INDEX [IX_FK_GroupRole_Groups]
ON [dbo].[GroupRoles]
    ([GroupID]);
GO

-- Creating foreign key on [Role] in table 'GroupRoles'
ALTER TABLE [dbo].[GroupRoles]
ADD CONSTRAINT [FK_GroupRole_Roles]
    FOREIGN KEY ([Role])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupRole_Roles'
CREATE INDEX [IX_FK_GroupRole_Roles]
ON [dbo].[GroupRoles]
    ([Role]);
GO

-- Creating foreign key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_Roles]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Roles'
CREATE INDEX [IX_FK_UserRole_Roles]
ON [dbo].[UserRoles]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_User'
CREATE INDEX [IX_FK_UserRole_User]
ON [dbo].[UserRoles]
    ([UserID]);
GO

-- Creating foreign key on [ClientID] in table 'WorkItems'
ALTER TABLE [dbo].[WorkItems]
ADD CONSTRAINT [FK_WorkItem_Clients]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ClientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkItem_Clients'
CREATE INDEX [IX_FK_WorkItem_Clients]
ON [dbo].[WorkItems]
    ([ClientID]);
GO

-- Creating foreign key on [WorkItemID] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_Documents_WorkItem]
    FOREIGN KEY ([WorkItemID])
    REFERENCES [dbo].[WorkItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_WorkItem'
CREATE INDEX [IX_FK_Documents_WorkItem]
ON [dbo].[Documents]
    ([WorkItemID]);
GO

-- Creating foreign key on [WorkItemID] in table 'WorkItemFields'
ALTER TABLE [dbo].[WorkItemFields]
ADD CONSTRAINT [FK_WorkItemField_WorkItem]
    FOREIGN KEY ([WorkItemID])
    REFERENCES [dbo].[WorkItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkItemField_WorkItem'
CREATE INDEX [IX_FK_WorkItemField_WorkItem]
ON [dbo].[WorkItemFields]
    ([WorkItemID]);
GO

-- Creating foreign key on [UserID] in table 'VarificationNumbers'
ALTER TABLE [dbo].[VarificationNumbers]
ADD CONSTRAINT [FK_VarificationNumbers_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VarificationNumbers_Users'
CREATE INDEX [IX_FK_VarificationNumbers_Users]
ON [dbo].[VarificationNumbers]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------