
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2019 23:15:06
-- Generated from EDMX file: C:\Users\Yaswell\Desktop\ITLA\Programacion 3\Programas\GRHm\GRHm\Models\EmplModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GestionRecursosHumanos];
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

-- Creating table 'EmpleadoSet'
CREATE TABLE [dbo].[EmpleadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoEmpleado] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Telefono] int  NOT NULL,
    [Departamento] nvarchar(max)  NOT NULL,
    [Cargo] nvarchar(max)  NOT NULL,
    [FechadeNac] datetime  NOT NULL,
    [Salario] int  NOT NULL,
    [Estatus] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepartamentoSet'
CREATE TABLE [dbo].[DepartamentoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoDepartamento] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CargoSet'
CREATE TABLE [dbo].[CargoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomCargo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NominaSet'
CREATE TABLE [dbo].[NominaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Año] int  NOT NULL,
    [Mes] int  NOT NULL,
    [MontoTotal] int  NOT NULL
);
GO

-- Creating table 'PermisosSet'
CREATE TABLE [dbo].[PermisosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL,
    [Motivo] nvarchar(max)  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SalidaEMpleadosSet'
CREATE TABLE [dbo].[SalidaEMpleadosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Empleado] nvarchar(max)  NOT NULL,
    [TipoSalida] nvarchar(max)  NOT NULL,
    [Motivo] nvarchar(max)  NOT NULL,
    [FechaSalida] datetime  NOT NULL
);
GO

-- Creating table 'VacacionesSet'
CREATE TABLE [dbo].[VacacionesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Desde] datetime  NOT NULL,
    [Hasta] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmpleadoSet'
ALTER TABLE [dbo].[EmpleadoSet]
ADD CONSTRAINT [PK_EmpleadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepartamentoSet'
ALTER TABLE [dbo].[DepartamentoSet]
ADD CONSTRAINT [PK_DepartamentoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CargoSet'
ALTER TABLE [dbo].[CargoSet]
ADD CONSTRAINT [PK_CargoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NominaSet'
ALTER TABLE [dbo].[NominaSet]
ADD CONSTRAINT [PK_NominaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermisosSet'
ALTER TABLE [dbo].[PermisosSet]
ADD CONSTRAINT [PK_PermisosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SalidaEMpleadosSet'
ALTER TABLE [dbo].[SalidaEMpleadosSet]
ADD CONSTRAINT [PK_SalidaEMpleadosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VacacionesSet'
ALTER TABLE [dbo].[VacacionesSet]
ADD CONSTRAINT [PK_VacacionesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------