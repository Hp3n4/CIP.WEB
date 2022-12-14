USE [master]
GO
/****** Object:  Database [CIP]    Script Date: 10/08/2022 11:19:31 ******/
CREATE DATABASE [CIP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CIP', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CIP.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CIP_log', FILENAME = N'G:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CIP_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CIP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CIP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CIP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CIP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CIP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CIP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CIP] SET ARITHABORT OFF 
GO
ALTER DATABASE [CIP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CIP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CIP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CIP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CIP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CIP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CIP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CIP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CIP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CIP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CIP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CIP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CIP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CIP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CIP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CIP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CIP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CIP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CIP] SET RECOVERY FULL 
GO
ALTER DATABASE [CIP] SET  MULTI_USER 
GO
ALTER DATABASE [CIP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CIP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CIP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CIP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CIP]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 10/08/2022 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Especialidades](
	[IdEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Postulantes]    Script Date: 10/08/2022 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Postulantes](
	[IdPostulante] [int] IDENTITY(1,1) NOT NULL,
	[DatosPostulante] [varchar](100) NULL,
	[DNI] [char](8) NULL,
	[Fecha] [datetime] NULL,
	[Telefono] [char](9) NULL,
	[IdEspecialidad] [int] NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPostulante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/08/2022 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Descripcion] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/08/2022 11:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NULL,
	[Contraseña] [varchar](50) NULL,
	[Bloqueado] [bit] NULL,
	[Datos] [varchar](100) NULL,
	[IdRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidades] ON 

INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (2, N'INGENERIA AGRONOMA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (3, N'INGENERIA CIVIL', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (4, N'INGENERIA ECONOMIA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (5, N'INGENERIA ELECTRICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (6, N'INGENERIA ELECTRONICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (7, N'INGENERIA FORESTAL', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (8, N'INGENERIA GEOLOGICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (9, N'INGENERIA INDUSTRIAL Y SISTEMAS', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (10, N'INGENERIA INDUSTRIAS ALIMENTARIAS Y AGROINDUSTRIAS', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (11, N'INGENERIA MECANICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (12, N'INGENERIA MECANICA Y ELECTRICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (13, N'INGENERIA METALURGICA', N'  ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (14, N'INGENERIA MINAS', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (15, N'INGENERIA PESQUERIA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (16, N'INGENERIA PETROLEO Y PETROQUIMICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (17, N'INGENERIA QUIMICA', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (18, N'INGENERIA SANITARIA Y AMBIENTAL', N' ')
INSERT [dbo].[Especialidades] ([IdEspecialidad], [Nombre], [Descripcion]) VALUES (19, N'INGENERIA ZOOTECNIA', N' ')
SET IDENTITY_INSERT [dbo].[Especialidades] OFF
SET IDENTITY_INSERT [dbo].[Postulantes] ON 

INSERT [dbo].[Postulantes] ([IdPostulante], [DatosPostulante], [DNI], [Fecha], [Telefono], [IdEspecialidad], [IdUsuario]) VALUES (2, N'Alcazar Barranca Sergio', N'72669686', CAST(0x0000AEEB00000000 AS DateTime), N'940986174', 2, 1)
INSERT [dbo].[Postulantes] ([IdPostulante], [DatosPostulante], [DNI], [Fecha], [Telefono], [IdEspecialidad], [IdUsuario]) VALUES (3, N'PEÑA RUIZ HUMBERTO JOSE', N'45549539', CAST(0x0000AEED001CB1C9 AS DateTime), N'969744839', 9, 1)
SET IDENTITY_INSERT [dbo].[Postulantes] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRol], [Nombre], [Descripcion]) VALUES (1, N'ADM', N'Administrador')
INSERT [dbo].[Roles] ([IdRol], [Nombre], [Descripcion]) VALUES (2, N'REC', N'Recepcionista')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña], [Bloqueado], [Datos], [IdRol]) VALUES (1, N'root', N'root', 0, N'Root Root', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contraseña], [Bloqueado], [Datos], [IdRol]) VALUES (2, N'hpeña', N'hpeña', 0, N'Humberto Peña', 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
ALTER TABLE [dbo].[Postulantes]  WITH CHECK ADD  CONSTRAINT [FK_Postulantes_Especialidades] FOREIGN KEY([IdEspecialidad])
REFERENCES [dbo].[Especialidades] ([IdEspecialidad])
GO
ALTER TABLE [dbo].[Postulantes] CHECK CONSTRAINT [FK_Postulantes_Especialidades]
GO
ALTER TABLE [dbo].[Postulantes]  WITH CHECK ADD  CONSTRAINT [FK_Postulantes_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Postulantes] CHECK CONSTRAINT [FK_Postulantes_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [CIP] SET  READ_WRITE 
GO
