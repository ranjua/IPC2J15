USE [master]
GO
/****** Object:  Database [ProyectoIPC2]    Script Date: 03/07/2015 1:14:35 ******/
CREATE DATABASE [ProyectoIPC2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoIPC2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RJNMSSQLSERVER\MSSQL\DATA\ProyectoIPC2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProyectoIPC2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.RJNMSSQLSERVER\MSSQL\DATA\ProyectoIPC2_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProyectoIPC2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoIPC2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoIPC2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoIPC2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoIPC2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoIPC2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoIPC2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoIPC2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoIPC2] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoIPC2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoIPC2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoIPC2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoIPC2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProyectoIPC2]
GO
/****** Object:  StoredProcedure [dbo].[PaqueteImpuesto]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROcedure [dbo].[PaqueteImpuesto]
as
begin
Select i.categoria, Count(p.cod_paquete) as Recibidos, sum(case when p.estado = 'Perdido' then 1 else 0 end) as Perdidos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') then 1 else 0 end) as Entregados,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo) * Convert(float,i.porcentaje))) else 0 end) as Impuestos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.libras)* Convert(float,s.costo_lb))) else 0 end) as Costo_Libra,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo)* Convert(float,s.comision))) else 0 end) as Comisiones
from ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Lotes l, ProyectoIPC2.dbo.Sucursales s
where p.cod_impuesto=i.cod_impuesto and p.cod_lote=l.cod_lote and l.cod_sucursal= s.cod_sucursal  group by i.categoria; 
end
GO
/****** Object:  StoredProcedure [dbo].[PaqueteSucursal]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[PaqueteSucursal]
as
begin
Select s.nombre, count(p.cod_paquete) as Recibidos, 
sum(case when p.estado = 'Perdido' then 1 else 0 end) as Perdidos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') then 1 else 0 end) as Entregados,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo) * Convert(float,i.porcentaje))) 
else 0 end) as Impuestos,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.libras)* Convert(float,s.costo_lb))) 
else 0 end) as Costo_Libra,
sum(case when (p.estado='Facturado' or p.estado='Devolucion' or p.estado='Devuelto') 
then ((Convert(float,p.costo)* Convert(float, s.comision))) 
else 0 end) as Comisiones
from ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Lotes l, ProyectoIPC2.dbo.Sucursales s
where p.cod_impuesto=i.cod_impuesto and p.cod_lote=l.cod_lote and l.cod_sucursal= s.cod_sucursal  group by s.nombre; 
end
GO
/****** Object:  StoredProcedure [dbo].[ResumenEmpleado]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ResumenEmpleado]
as
begin

select s.nombre as Sucursal, d.nombre as Departamento, count(e.cod_empleado) as Empleados, 
SUM(CONVERT(float,e.sueldo)) as Sueldos from ProyectoIPC2.dbo.Empleados e, ProyectoIPC2.dbo.Usuarios u, 
ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Departamentos d,ProyectoIPC2.dbo.SucDep sd 
where s.cod_sucursal = sd.cod_sucursal and d.cod_departamento =sd.cod_departamento and 
e.cod_usuario = u.cod_usuario and sd.cod_Suc_Dep=e.cod_suc_dep group by s.nombre, d.nombre

end
GO
/****** Object:  StoredProcedure [dbo].[T5Impuestos]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[T5Impuestos]
as
begin

select i.categoria, Count(p.cod_impuesto) as Cantidad_de_importacion, 
Sum((convert(float,f.comision)* p.costo) + (convert(float,f.costo_libra)* p.libras)) as Ganancias
from ProyectoIPC2.dbo.Impuestos i, ProyectoIPC2.dbo.Paquetes p, ProyectoIPC2.dbo.Sucursales s, ProyectoIPC2.dbo.Facturas f 
where f.cod_paquete=p.cod_paquete and i.cod_impuesto=p.cod_impuesto and s.cod_sucursal = 1 
group by i.categoria order by Count(p.cod_impuesto) desc;

end
GO
/****** Object:  Table [dbo].[botones]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[botones](
	[cod_botones] [int] NOT NULL,
	[texto] [nvarchar](45) NOT NULL,
	[pag_dest] [nvarchar](100) NOT NULL,
	[tool_tip] [nvarchar](100) NOT NULL,
	[num_orden] [int] NOT NULL,
	[cod_padre] [int] NOT NULL,
	[nivel] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[botonrol]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[botonrol](
	[cod_BR] [int] NOT NULL,
	[cod_Boton] [int] NOT NULL,
	[cod_Rol] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[DPI] [nvarchar](50) NOT NULL,
	[NIT] [varchar](50) NOT NULL,
	[num_tarjeta_C_D] [nvarchar](50) NOT NULL,
	[casilla] [int] IDENTITY(1000,1) NOT NULL,
	[DPI_entrega] [nvarchar](50) NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_autorizador] [int] NULL,
	[cod_sucursal] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[DPI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departamentos](
	[cod_departamento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[cod_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Devoluciones]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devoluciones](
	[cod_devolucion] [int] IDENTITY(1,1) NOT NULL,
	[devuelto] [bit] NOT NULL,
	[cod_paquete] [int] NOT NULL,
 CONSTRAINT [PK_Devoluciones] PRIMARY KEY CLUSTERED 
(
	[cod_devolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[cod_empleado] [int] IDENTITY(100,1) NOT NULL,
	[sueldo] [varchar](50) NOT NULL,
	[cod_suc_dep] [int] NOT NULL,
	[cod_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[cod_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas](
	[cod_factura] [int] IDENTITY(1000,1) NOT NULL,
	[comision] [varchar](50) NOT NULL,
	[costo_libra] [varchar](50) NOT NULL,
	[impuesto] [varchar](50) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[hora] [varchar](50) NOT NULL,
	[cod_paquete] [int] NULL,
	[cod_facturador] [int] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[cod_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Historial_E]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Historial_E](
	[cod_historial_e] [int] IDENTITY(1,1) NOT NULL,
	[cod_empleado] [int] NOT NULL,
	[cod_director] [int] NOT NULL,
	[cod_suc_dep] [int] NOT NULL,
	[sueldo] [varchar](50) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[hora] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Historial_E] PRIMARY KEY CLUSTERED 
(
	[cod_historial_e] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Historial_P]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Historial_P](
	[cod_historial_p] [int] IDENTITY(1,1) NOT NULL,
	[cod_paquete] [int] NOT NULL,
	[cod_empleado] [int] NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[hora] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Historial_P] PRIMARY KEY CLUSTERED 
(
	[cod_historial_p] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Impuestos](
	[cod_impuesto] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [varchar](50) NOT NULL,
	[porcentaje] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Impuestos] PRIMARY KEY CLUSTERED 
(
	[cod_impuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lotes]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lotes](
	[cod_lote] [int] IDENTITY(1,1) NOT NULL,
	[fecha_salida] [varchar](50) NOT NULL,
	[fecha_aduana] [varchar](50) NULL,
	[fecha_llegada] [varchar](50) NULL,
	[cod_sucursal] [int] NOT NULL,
 CONSTRAINT [PK_Lotes] PRIMARY KEY CLUSTERED 
(
	[cod_lote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paquetes]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paquetes](
	[cod_paquete] [int] IDENTITY(1,1) NOT NULL,
	[costo] [varchar](50) NOT NULL,
	[libras] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[cod_cliente] [varchar](50) NOT NULL,
	[cod_empleado] [int] NOT NULL,
	[cod_impuesto] [int] NOT NULL,
	[cod_pedido] [int] NULL,
	[cod_lote] [int] NOT NULL,
	[img] [varchar](500) NULL,
 CONSTRAINT [PK_Paquetes] PRIMARY KEY CLUSTERED 
(
	[cod_paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[cod_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varbinary](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SucDep]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucDep](
	[cod_Suc_Dep] [int] IDENTITY(1,1) NOT NULL,
	[cod_sucursal] [int] NOT NULL,
	[cod_departamento] [int] NOT NULL,
 CONSTRAINT [PK_SucDep] PRIMARY KEY CLUSTERED 
(
	[cod_Suc_Dep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursales](
	[cod_sucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[sede] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[max_empleados] [int] NOT NULL,
	[comision] [varchar](50) NOT NULL,
	[costo_lb] [varchar](50) NOT NULL,
	[hcomision] [bit] NOT NULL,
	[hcosto_lb] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[cod_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 03/07/2015 1:14:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[cod_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[pass] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[domicilio] [varchar](50) NOT NULL,
	[cod_rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[cod_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (1, N'Carga Masiva de Datos Administrativos', N'Administrador/Carga_Masiva.aspx', N'Carga Masiva', 1, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (2, N'Gestion de Cobros a Paquetes', N'Administrador/Gestion_Cobros.aspx', N'Gestion de Cobros', 2, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (3, N'Despliege de Equipo en Quetzal Express', N'Director/Consultar_Equipo.aspx', N'Consultar Equipo', 1, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (4, N'Contratacion de Nuevo Personal', N'Director/Contratacion.aspx', N'Contratacion de Personal', 2, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (5, N'Facturacion a Clientes', N'Empleados/Facturacion.aspx', N'Facturacion', 1, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (6, N'Informacion de Estado de Paquetes', N'Cliente/Info_Paquetes.aspx', N'Informacion de Paquetes', 1, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (7, N'Perfil Usuario', N'Cliente/Perfil_Cliente.aspx', N'Perfil de Usuario', 2, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (8, N'Cotizacion de Paquete', N'Cliente/Cotizacion.aspx', N'Cotizacion para Paquete estimada', 3, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (9, N'Registro de Paquetes al Sistema', N'Empleados/Registro_de_Paquetes.aspx', N'Agregar Paquetes al Sistema Para Envio', 2, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (10, N'Reportar Paquetes Perdidos', N'Empleados/Reportar_Paquete_Perdido.aspx', N'Reportar Paquete Perdido Mediate CSV', 3, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (11, N'Devolver Paquetes', N'Empleados/Devolucion.aspx', N'Devolver Paquetes', 4, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (12, N'Agregar Sucursal o Departamento', N'Administrador/Sucursal_Departamento.aspx', N'Agregar sucursal o departamento', 3, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (13, N'Autorizar Clientes', N'Empleados/Autorizacion.aspx', N'Autorizar a clientes nuevos en el sistema', 5, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (15, N'Cargar foto de Factura de Producto', N'Cliente/Foto_Precio.aspx', N'Cargar foto para ingresar precio', 4, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (16, N'Agregar Precio a Paquete', N'Empleados/Agregar_Precio.aspx', N'Agregarle el precio a los paquete sin precio por medio de una foto de la factura', 7, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (17, N'Autorizar Precio a Paquete', N'Director/Autorizar_Precio.aspx', N'Autorizarle el precio a los paquetes', 3, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (18, N'Reportes', N'Administrador/Reportes.aspx', N'Generar Reportes En PDF, Xml, Dos', 4, 0, 0)
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (14, N'Cambiar estado a Lotes', N'Empleados/Estado_Lote.aspx', N'Cambiar estado a lote', 6, 0, 0)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (1, 1, 1)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (2, 2, 1)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (3, 3, 2)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (4, 4, 2)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (5, 5, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (6, 6, 4)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (7, 7, 4)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (8, 8, 4)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (9, 9, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (10, 10, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (11, 11, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (12, 12, 1)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (13, 13, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (14, 14, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (15, 15, 4)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (16, 16, 3)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (17, 17, 2)
INSERT [dbo].[botonrol] ([cod_BR], [cod_Boton], [cod_Rol]) VALUES (18, 18, 1)
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'23000200210', N'45654sdf', N'140000256', 1009, N'23000200210', 1022, 104, 4)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'5000803156457', N'666', N'5088888064', 1006, N'5000803156457', 9, 100, 12)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'5050', N'5050', N'5050', 1010, N'5050', 1023, 104, 4)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'505080809040', N'654321', N'654654654', 1008, N'505080809040', 1021, 104, 3)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'9090808060601', N'50213558-K', N'102313517', 1007, N'9090808060601', 1020, 104, 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (1, N'Recursos Humanos')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (6, N'Registro')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (7, N'Servicio al Cliente')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (8, N'Bodega')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (100, N'200', 1, 1)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (103, N'100', 6, 14)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (104, N'100', 6, 15)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (105, N'300', 8, 16)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (106, N'100', 6, 17)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (107, N'500', 7, 18)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (108, N'300', 8, 19)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (109, N'200', 1, 20)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (110, N'100', 6, 21)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (111, N'500', 7, 22)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (112, N'300', 8, 23)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (113, N'200', 1, 24)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (115, N'100', 6, 26)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (117, N'100', 6, 28)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (118, N'100', 6, 29)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (119, N'100', 6, 30)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (120, N'100', 6, 31)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (121, N'9000', 1, 32)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (122, N'500', 1, 33)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (123, N'500', 1, 34)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (2023, N'0.078', N'5.33', N'0.15', N'26/06/2015', N'23:50:57', 1038, 104)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (2024, N'0.078', N'5.33', N'0.11', N'26/06/2015', N'23:51:09', 1039, 104)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (2025, N'0.078', N'5.33', N'0.15', N'26/06/2015', N'23:51:17', 1040, 104)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (2026, N'0.078', N'5.33', N'0.11', N'26/06/2015', N'23:53:24', 1041, 104)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (2027, N'0.078', N'5.33', N'0.06', N'26/06/2015', N'23:59:04', 1043, 104)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
SET IDENTITY_INSERT [dbo].[Historial_E] ON 

INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (3, 123, 103, 1, N'500', N'26/06/2015', N'01:08:41')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (4, 122, 103, 1, N'500', N'26/06/2015', N'01:09:04')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (5, 121, 103, 6, N'500', N'26/06/2015', N'01:09:43')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (6, 121, 103, 6, N'900', N'26/06/2015', N'01:10:47')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (7, 121, 103, 6, N'500.4', N'26/06/2015', N'01:10:55')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (8, 121, 103, 6, N'100', N'26/06/2015', N'01:11:02')
INSERT [dbo].[Historial_E] ([cod_historial_e], [cod_empleado], [cod_director], [cod_suc_dep], [sueldo], [fecha], [hora]) VALUES (9, 121, 103, 1, N'9000', N'26/06/2015', N'01:11:11')
SET IDENTITY_INSERT [dbo].[Historial_E] OFF
SET IDENTITY_INSERT [dbo].[Historial_P] ON 

INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (48, 1038, 104, N'EEUU', N'26/06/2015', N'23:37:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (49, 1039, 104, N'EEUU', N'26/06/2015', N'23:37:21')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (50, 1040, 104, N'EEUU', N'26/06/2015', N'23:37:26')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (51, 1041, 104, N'EEUU', N'26/06/2015', N'23:37:31')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (52, 1042, 104, N'EEUU', N'26/06/2015', N'23:37:35')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (53, 1043, 104, N'EEUU', N'26/06/2015', N'23:37:42')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (54, 1038, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (55, 1039, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (56, 1040, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (57, 1041, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (58, 1042, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (59, 1043, 104, N'Aduana', N'26/06/2015', N'23:49:32')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (60, 1038, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (61, 1039, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (62, 1040, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (63, 1041, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (64, 1042, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (65, 1043, 104, N'Guatemala', N'26/06/2015', N'23:50:03')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (66, 1038, 104, N'Facturado', N'26/06/2015', N'23:50:58')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (67, 1039, 104, N'Facturado', N'26/06/2015', N'23:51:10')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (68, 1040, 104, N'Facturado', N'26/06/2015', N'23:51:17')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (69, 1041, 104, N'Facturado', N'26/06/2015', N'23:58:53')
INSERT [dbo].[Historial_P] ([cod_historial_p], [cod_paquete], [cod_empleado], [estado], [fecha], [hora]) VALUES (70, 1043, 104, N'Facturado', N'26/06/2015', N'23:59:04')
SET IDENTITY_INSERT [dbo].[Historial_P] OFF
SET IDENTITY_INSERT [dbo].[Impuestos] ON 

INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (7, N'Accesorio de Telefonia', N'0.15', 0)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (8, N'Accesorio Deportivo', N'0.1', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (9, N'Articulos de Cuero', N'0.15', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (10, N'Videojuegos', N'0.11', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (12, N'Lociones', N'0.05', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (13, N'Cosmeticos', N'0.06', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (14, N'1', N'0.01', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (15, N'2', N'0.02', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (16, N'3', N'0.03', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (17, N'4', N'0.05', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (18, N'5', N'0.5', 0)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (1013, N'Goles', N'0.28', 1)
SET IDENTITY_INSERT [dbo].[Impuestos] OFF
SET IDENTITY_INSERT [dbo].[Lotes] ON 

INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (1, N'16/07/2015', N'21/07/2015', N'26/07/2015', 1)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (2, N'16/07/2015', N'21/07/2015', N'26/07/2015', 3)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (3, N'16/07/2015', N'21/07/2015', N'26/07/2015', 4)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (4, N'16/08/2015', N'21/08/2015', N'26/08/2015', 1)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (5, N'16/08/2015', N'21/08/2015', N'26/08/2015', 3)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (6, N'16/08/2015', N'21/08/2015', N'26/08/2015', 4)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (7, N'16/09/2015', N'21/09/2015', N'26/09/2015', 1)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (8, N'16/09/2015', N'21/09/2015', N'26/09/2015', 3)
INSERT [dbo].[Lotes] ([cod_lote], [fecha_salida], [fecha_aduana], [fecha_llegada], [cod_sucursal]) VALUES (9, N'16/09/2015', N'21/09/2015', N'26/09/2015', 4)
SET IDENTITY_INSERT [dbo].[Lotes] OFF
SET IDENTITY_INSERT [dbo].[Paquetes] ON 

INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1038, N'500', N'10', N'Facturado', N'5050', 104, 7, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1039, N'500', N'10', N'Facturado', N'5050', 104, 8, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1040, N'500', N'10', N'Facturado', N'5050', 104, 9, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1041, N'500', N'10', N'Facturado', N'5050', 104, 10, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1042, N'500', N'10', N'Perdido', N'5050', 104, 12, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1043, N'500', N'10', N'Facturado', N'5050', 104, 13, NULL, 3, N'')
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote], [img]) VALUES (1044, N'500', N'10', N'EEUU', N'5050', 104, 13, NULL, 1, N'')
SET IDENTITY_INSERT [dbo].[Paquetes] OFF
SET IDENTITY_INSERT [dbo].[SucDep] ON 

INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (1, 1, 1)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (3, 3, 1)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (6, 11, 6)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (7, 12, 7)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (8, 12, 8)
SET IDENTITY_INSERT [dbo].[SucDep] OFF
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (1, N'Reforma', N'Guatemala', 50005000, 100, N'0.078', N'5.33', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (3, N'Terminal', N'Guatemala', 60006000, 80, N'0.078', N'5.33', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (4, N'Mixco', N'Guatemala', 60006000, 80, N'0.078', N'5.33', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (5, N'Los Angeles', N'Estados Unidos', 800643251, 20, N'0.078', N'5.33', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (11, N'Miami FL', N'Estados Unidos', 50000000, 100, N'0.078', N'5.33', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (12, N'Ciudad de Guatemala', N'Guatemala', 50000000, 100, N'0.078', N'5.33', 1, 1)
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1, N'100', N'empleado', N'Fern25', N'Juar2', N'50505050', N'randy@h', N'50-80', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (9, N'5000803156457', N'cliente', N'Ped', N'Juan', N'50505050', N'ped@hot.com', N'50-80', 4)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (10, N'98', N'admin', N'Fern25', N'Juar2', N'50505050', N'randy@h', N'50-80', 1)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (14, N'103', N'103', N' Hannah', N'Abbott', N'0', N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (15, N'104', N'104', N' Hannah', N'Abbott', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (16, N'105', N'105', N' Hannah', N'Abbott', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (17, N'106', N'empleado', N' Hannah', N'Abbott', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (18, N'107', N'empleado', N'Juan', N'Chap?n', N'0', N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (19, N'108', N'empleado', N'Jos? Luis', N'L?pez Mart?nez', N'0', N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (20, N'109', N'empleado', N'John', N'Johnson', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (21, N'110', N'empleado', N'Hannah', N'Abbott', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (22, N'111', N'empleado', N'Juan', N'Chap?n', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (23, N'112', N'empleado', N'Jos? Luis', N'L?pez Mart?nez', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (24, N'113', N'empleado', N'John', N'Johnson', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (26, N'115', N'empleado', N'Juan', N'Perez', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (27, N'116', N'empleado', N'Blanca', N'Nieves', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (28, N'117', N'empleado', N'Enano', N'Uno', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (29, N'118', N'empleado', N'Enano', N'Segundo', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (30, N'119', N'empleado', N'Enano', N'Tercero', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (31, N'120', N'empleado', N'Enano', N'Cuarta', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (32, N'121', N'empleado', N'Enano', N'Quinto', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (33, N'122', N'empleado', N'Enano', N'Sexto', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (34, N'123', N'empleado', N'Enano', N'Septimo', N'0', N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1020, N'9090808060601', N'9090808060601', N'Perdido', N'Encontrado', N'5080960643', N'perdidoencrontrado@hothto.com', N'5080-90', 4)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1021, N'505080809040', N'505080809040', N'ran', N'fer', N'654987321', N'randy@ho55', N'564897-65', 4)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1022, N'23000200210', N'23000200210', N'fer', N'rand', N'6549872', N'rnn@ho', N'645654d', 4)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1023, N'5050', N'5050', N'5050', N'8080', N'5005', N'5050@5050', N'5050', 4)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Impuestos]    Script Date: 03/07/2015 1:14:35 ******/
ALTER TABLE [dbo].[Impuestos] ADD  CONSTRAINT [IX_Impuestos] UNIQUE NONCLUSTERED 
(
	[categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_cod_autorizador]  DEFAULT ((100)) FOR [cod_autorizador]
GO
USE [master]
GO
ALTER DATABASE [ProyectoIPC2] SET  READ_WRITE 
GO
