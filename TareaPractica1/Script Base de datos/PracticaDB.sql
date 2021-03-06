USE [master]
GO
/****** Object:  Database [Practica1IPC2]    Script Date: 15/06/2015 23:45:22 ******/
CREATE DATABASE [Practica1IPC2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Practica1IPC2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RJNMSSQLSERVER\MSSQL\DATA\Practica1IPC2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Practica1IPC2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RJNMSSQLSERVER\MSSQL\DATA\Practica1IPC2_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Practica1IPC2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Practica1IPC2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Practica1IPC2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Practica1IPC2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Practica1IPC2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Practica1IPC2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Practica1IPC2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Practica1IPC2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Practica1IPC2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Practica1IPC2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Practica1IPC2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Practica1IPC2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Practica1IPC2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Practica1IPC2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Practica1IPC2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Practica1IPC2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Practica1IPC2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Practica1IPC2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Practica1IPC2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Practica1IPC2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Practica1IPC2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Practica1IPC2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Practica1IPC2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Practica1IPC2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Practica1IPC2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Practica1IPC2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Practica1IPC2] SET  MULTI_USER 
GO
ALTER DATABASE [Practica1IPC2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Practica1IPC2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Practica1IPC2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Practica1IPC2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Practica1IPC2]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 15/06/2015 23:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[autores](
	[cod_autor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED 
(
	[cod_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 15/06/2015 23:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientes](
	[carnet] [bigint] IDENTITY(20150000,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[DPI] [bigint] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [bigint] NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[carnet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[libros]    Script Date: 15/06/2015 23:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[libros](
	[cod_registro] [int] IDENTITY(1,1) NOT NULL,
	[cod_libro] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[paginas] [int] NOT NULL,
	[tema] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[cod_autor] [int] NOT NULL,
 CONSTRAINT [PK_libros] PRIMARY KEY CLUSTERED 
(
	[cod_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prestamos]    Script Date: 15/06/2015 23:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prestamos](
	[cod_prestamo] [int] IDENTITY(1,1) NOT NULL,
	[fecha_prestamo] [varchar](50) NOT NULL,
	[fecha_entrega] [varchar](50) NULL,
	[cod_cliente] [int] NOT NULL,
	[cod_registro_libro] [int] NOT NULL,
	[devuelto] [bit] NOT NULL,
 CONSTRAINT [PK_prestamos] PRIMARY KEY CLUSTERED 
(
	[cod_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reservas]    Script Date: 15/06/2015 23:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservas](
	[cod_reserva] [int] IDENTITY(1,1) NOT NULL,
	[cod_libro] [int] NOT NULL,
	[cod_cliente] [bigint] NOT NULL,
 CONSTRAINT [PK_reservas] PRIMARY KEY CLUSTERED 
(
	[cod_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[autores] ON 

INSERT [dbo].[autores] ([cod_autor], [nombre], [apellido]) VALUES (4, N'Anonimo', N' ')
INSERT [dbo].[autores] ([cod_autor], [nombre], [apellido]) VALUES (5, N'Jose', N'Armas')
INSERT [dbo].[autores] ([cod_autor], [nombre], [apellido]) VALUES (6, N'Juan', N'Pecoz')
INSERT [dbo].[autores] ([cod_autor], [nombre], [apellido]) VALUES (7, N'Mijia', N'Escobar')
INSERT [dbo].[autores] ([cod_autor], [nombre], [apellido]) VALUES (8, N'Hector', N'Mijares')
SET IDENTITY_INSERT [dbo].[autores] OFF
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150000, N'Pedro', 505080080403, N'15ave', 58996331)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150001, N'Pee', 508090601340, N'15ee', 987654321)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150002, N'Pee', 508090601340, N'15ee', 987654321)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150003, N'peo', 508064711618, N'15dd', 65484321)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150004, N'peo', 508064711609, N'15dd', 65484328)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150005, N'siiinoo', 505080806044, N'15sdf', 6549871)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150006, N'poe', 65498731321, N'df54', 321654987)
INSERT [dbo].[clientes] ([carnet], [nombre], [DPI], [direccion], [telefono]) VALUES (20150007, N'Pietro', 8080909040, N'15 avenida 5c', 50542312)
SET IDENTITY_INSERT [dbo].[clientes] OFF
SET IDENTITY_INSERT [dbo].[libros] ON 

INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (42, 5, N'Libro 1', 100, N'Tema 1', N'Prestado', 8)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (43, 5, N'Libro 1', 100, N'Tema 1', N'Prestado', 8)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (44, 5, N'Libro 1', 100, N'Tema 1', N'Disponible', 8)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (45, 5, N'Libro 1', 100, N'Tema 1', N'Disponible', 8)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (46, 6, N'Saber', 10, N'Terror', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (47, 6, N'Saber', 10, N'Terror', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (48, 6, N'Saber', 10, N'Terror', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (49, 6, N'Saber', 10, N'Terror', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (50, 6, N'Saber', 10, N'Terror', N'Prestado', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (51, 6, N'Saber', 10, N'Terror', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (52, 7, N'Libro Secreto', 70, N'Suspenso', N'Prestado', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (53, 7, N'Libro Secreto', 70, N'Suspenso', N'Disponible', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (54, 7, N'Libro Secreto', 70, N'Suspenso', N'Prestado', 4)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (55, 8, N'Super Libro Magia', 100, N'Magia', N'Disponible', 7)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (56, 8, N'Super Libro Magia', 100, N'Magia', N'Disponible', 7)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (57, 8, N'Super Libro Magia', 100, N'Magia', N'Disponible', 7)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (58, 8, N'Super Libro Magia', 100, N'Magia', N'Disponible', 7)
INSERT [dbo].[libros] ([cod_registro], [cod_libro], [nombre], [paginas], [tema], [estado], [cod_autor]) VALUES (59, 8, N'Super Libro Magia', 100, N'Magia', N'Disponible', 7)
SET IDENTITY_INSERT [dbo].[libros] OFF
SET IDENTITY_INSERT [dbo].[prestamos] ON 

INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (7, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150006, 52, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (8, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150006, 53, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (9, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150006, 54, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (10, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150004, 46, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (11, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150004, 42, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (12, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150004, 43, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (13, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150004, 49, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (14, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150003, 44, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (15, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150003, 45, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (16, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150002, 47, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (17, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150002, 48, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (18, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150002, 50, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (19, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150002, 51, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (20, N'15/06/2015 0:00:00', NULL, 20150006, 54, 0)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (21, N'15/06/2015 0:00:00', NULL, 20150006, 52, 0)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (22, N'15/06/2015 0:00:00', NULL, 20150006, 50, 0)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (23, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150002, 44, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (24, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150003, 42, 1)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (25, N'15/06/2015 0:00:00', NULL, 20150005, 42, 0)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (26, N'15/06/2015 0:00:00', NULL, 20150002, 43, 0)
INSERT [dbo].[prestamos] ([cod_prestamo], [fecha_prestamo], [fecha_entrega], [cod_cliente], [cod_registro_libro], [devuelto]) VALUES (27, N'15/06/2015 0:00:00', N'15/06/2015 0:00:00', 20150003, 55, 1)
SET IDENTITY_INSERT [dbo].[prestamos] OFF
USE [master]
GO
ALTER DATABASE [Practica1IPC2] SET  READ_WRITE 
GO
