USE [master]
GO

/****** Object:  Database [Estudo]    Script Date: 29/03/2025 16:05:14 ******/
CREATE DATABASE [Estudo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Estudo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Estudo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Estudo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Estudo_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO


USE [Estudo]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 29/03/2025 16:05:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](80) NOT NULL,
	[LastName] [varchar](80) NOT NULL,
	[Email] [varchar](160) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Insert data ********************************************************************/
INSERT INTO Customers VALUES('José', 'Bezerra', 'jose.bezerra@exemple.org', '123456', DATEFROMPARTS(1974, 3, 29), 1)
INSERT INTO Customers VALUES('José', 'Rodrigues', 'jose.rodrigues@exemple.org', '123456', DATEFROMPARTS(1974, 3, 29), 4)
INSERT INTO Customers VALUES('Antonio', 'Medrado', 'antonio@exemple.org', '123456', DATEFROMPARTS(1974, 3, 29), 4)
INSERT INTO Customers VALUES('Vitor Hugo', 'Almeida', 'vh.almeida@exemple.org', '123456', DATEFROMPARTS(1974, 3, 29), 1)
INSERT INTO Customers VALUES('Bernado', 'Campos', 'bernardocampos@exemple.org', '123456', DATEFROMPARTS(1974, 3, 29), 4)