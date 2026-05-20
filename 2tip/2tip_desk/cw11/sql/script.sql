CREATE DATABASE [studentsDb] ON PRIMARY 
( NAME = N'studentsDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\studentsDb.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )


CREATE TABLE [dbo].[Students] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Firstname]  NVARCHAR (50) NULL,
    [Lastname]   NVARCHAR (50) NULL,
    [Age]        INT           NULL,
    [DivisionId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Divisions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Students] ON
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (1, N'Jan', N'Kowalski', 19, 1)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (2, N'Irena', N'Malwik', 20, 1)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (3, N'Teresa', N'Grynek', 20, 1)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (4, N'Tomasz', N'Bomasz', 19, 2)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (5, N'Renata', N'Sałata', 20, 2)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (6, N'Czesław', N'Fanecki', 20, 2)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (7, N'Adam', N'Wałecki', 20, 3)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (8, N'Irena', N'Bronicka', 20, 3)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (9, N'Barbara', N'Rydzek', 19, 3)
INSERT INTO [dbo].[Students] ([Id], [Firstname], [Lastname], [Age], [DivisionId]) VALUES (10, N'Anna', N'Wann', 20, 3)
SET IDENTITY_INSERT [dbo].[Students] OFF

SET IDENTITY_INSERT [dbo].[Divisions] ON
INSERT INTO [dbo].[Divisions] ([Id], [Name], [Description]) VALUES (1, N'Matematyka', N'królowa nauk')
INSERT INTO [dbo].[Divisions] ([Id], [Name], [Description]) VALUES (2, N'Fizyka', N'nauka o przyrodzie')
INSERT INTO [dbo].[Divisions] ([Id], [Name], [Description]) VALUES (3, N'Informatyka', N'nauka o przetwarzania danych')
INSERT INTO [dbo].[Divisions] ([Id], [Name], [Description]) VALUES (4, N'Programowanie w C++', N'Podstawowy język obiektowy')
SET IDENTITY_INSERT [dbo].[Divisions] OFF