1. Создать БД с именем hometest
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hometest;Integrated Security=True;Pooling=False

2. Создать таблицу Employee
CREATE TABLE [dbo].[Employee] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    [age]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

3. Создать таблицу Department
CREATE TABLE [dbo].[Department] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

4. Создать таблицу связей Empl_Dep
CREATE TABLE [dbo].[Empl_Dep] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [IdEmpl] INT NOT NULL,
    [IdDep]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

5. Для заполнения тестовыми данными выполнить:

SET IDENTITY_INSERT [dbo].[Department] ON
INSERT INTO [dbo].[Department] ([Id], [name]) VALUES (1, N'Отдел вот такой 1')
INSERT INTO [dbo].[Department] ([Id], [name]) VALUES (2, N'Отдел 2')
INSERT INTO [dbo].[Department] ([Id], [name]) VALUES (3, N'Название 23')
INSERT INTO [dbo].[Department] ([Id], [name]) VALUES (4, N'Название 1')
SET IDENTITY_INSERT [dbo].[Department] OFF


SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (1, N'Vasya', 22)
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (2, N'dfd', 32)
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (3, N'Kolya', 23)
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (17, N'Имя', 18)
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (18, N'Имя', 18)
INSERT INTO [dbo].[Employee] ([Id], [name], [age]) VALUES (19, N'Имя 22', 18)
SET IDENTITY_INSERT [dbo].[Employee] OFF


SET IDENTITY_INSERT [dbo].[Empl_Dep] ON
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (1, 1, 1)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (2, 2, 2)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (3, 3, 1)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (4, 16, 2)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (5, 17, 2)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (6, 18, 1)
INSERT INTO [dbo].[Empl_Dep] ([Id], [IdEmpl], [IdDep]) VALUES (7, 19, 4)
SET IDENTITY_INSERT [dbo].[Empl_Dep] OFF
