CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (50)    NULL,
    [Surname]  NCHAR (50)    NULL,
    [Email]    VARCHAR (50)  NULL,
    [Password] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);