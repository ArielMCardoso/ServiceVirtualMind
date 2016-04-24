
USE [master]
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'BaseUsuarios')
DROP DATABASE [BaseUsuarios]
GO
CREATE DATABASE [BaseUsuarios] ON  PRIMARY 
( NAME = N'BaseUsuarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLSERVER2008\MSSQL\DATA\BaseUsuarios.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseUsuarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLSERVER2008\MSSQL\DATA\BaseUsuarios_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [BaseUsuarios] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseUsuarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BaseUsuarios] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BaseUsuarios] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BaseUsuarios] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BaseUsuarios] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BaseUsuarios] SET ARITHABORT OFF 
GO

ALTER DATABASE [BaseUsuarios] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BaseUsuarios] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [BaseUsuarios] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BaseUsuarios] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BaseUsuarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BaseUsuarios] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BaseUsuarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BaseUsuarios] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BaseUsuarios] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BaseUsuarios] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BaseUsuarios] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BaseUsuarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BaseUsuarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BaseUsuarios] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BaseUsuarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BaseUsuarios] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BaseUsuarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BaseUsuarios] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BaseUsuarios] SET  READ_WRITE 
GO

ALTER DATABASE [BaseUsuarios] SET RECOVERY FULL 
GO

ALTER DATABASE [BaseUsuarios] SET  MULTI_USER 
GO

ALTER DATABASE [BaseUsuarios] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BaseUsuarios] SET DB_CHAINING OFF 
GO
USE BaseUsuarios
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC,
	[Apellido] ASC,
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE #UsersTemp
(
	Nombre VARCHAR(50),
	Apellido VARCHAR(50),
	Email VARCHAR(100),
	Password VARCHAR(20)
)
INSERT INTO #UsersTemp (Nombre,Apellido,Email,Password)
VALUES ('JOSE','Mendoza','jose_Mendoza@gmail.com','JMendoza'),
('ARGIMIRO','Rodríguez','argimiro_Rodríguez@gmail.com','ARodríguez'), 
('JERUSALEM','Espinoza','jerusalem_Espinoza@gmail.com','JEspinoza'),
('MELIPAL','López','melipal_López@gmail.com','MLópez'),
('ETHEL','Bustos','ethel_Bustos@gmail.com','EBustos'),
('APOLONIA','Muñoz','apolonia_Muñoz@gmail.com','AMuñoz'),
('DOLFINA','Farías','dolfina_Farías@gmail.com','DFarías'),
('LINO','Ramírez','lino_Ramírez@gmail.com','LRamírez'),
('ULISES','Soto','ulises_Soto@gmail.com','USoto'),
('NADIA','Díaz','nadia_Díaz@gmail.com','NDíaz'),
('AIMIR','Hernández','aimir_Hernández@gmail.com','AHernández'),
('ABDIAS','Castillo','abdias_Castillo@gmail.com','ACastillo'),
('ESTRELLA','Bravo','estrella_Bravo@gmail.com','EBravo'),
('ABENAMAR','Henríquez','abenamar_Henríquez@gmail.com','AHenríquez'),
('GALIT','Rodríguez','galit_Rodríguez@gmail.com','GRodríguez'),
('ARMONIA','Zúñiga','armonia_Zúñiga@gmail.com','AZúñiga'),
('ORIEL','Castillo','oriel_Castillo@gmail.com','OCastillo')

INSERT INTO Users (Nombre, Apellido, Email, Password)
SELECT Nombre, Apellido, Email, Password
FROM #UsersTemp UT
WHERE NOT EXISTS 
		(SELECT 1 
		 FROM Users 
		 WHERE UT.Nombre = Nombre AND UT.Apellido = Apellido AND UT.Email = Email)
SELECT * FROM Users