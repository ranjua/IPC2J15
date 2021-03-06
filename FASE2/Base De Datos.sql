USE [ProyectoIPC2]
GO
/****** Object:  Table [dbo].[botones]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[botonrol]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Departamentos]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Devoluciones]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Empleados]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Facturas]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Impuestos]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Lotes]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Paquetes]    Script Date: 23/06/2015 1:51:33 ******/
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
 CONSTRAINT [PK_Paquetes] PRIMARY KEY CLUSTERED 
(
	[cod_paquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 23/06/2015 1:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pedidos](
	[cod_pedido] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[hora] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[cod_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perdidos]    Script Date: 23/06/2015 1:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perdidos](
	[cod_perdido] [int] IDENTITY(1,1) NOT NULL,
	[cod_paquete] [int] NOT NULL,
	[cod_lote] [int] NOT NULL,
 CONSTRAINT [PK_Perdidos] PRIMARY KEY CLUSTERED 
(
	[cod_perdido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[SucDep]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Sucursales]    Script Date: 23/06/2015 1:51:33 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/06/2015 1:51:33 ******/
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
	[telefono] [int] NOT NULL,
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
INSERT [dbo].[botones] ([cod_botones], [texto], [pag_dest], [tool_tip], [num_orden], [cod_padre], [nivel]) VALUES (13, N'Cambiar estado a Lotes', N'Empleados/Estado_Lote.aspx', N'Cambiar estado a lote', 5, 0, 0)
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
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'5000803156451', N'50213548-K', N'5088888064', 1001, N'5000803156457', 3, 0, 3)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'5000803156452', N'50213548-K', N'5088888064', 1005, N'5000803156457', 6, 0, 3)
INSERT [dbo].[Clientes] ([DPI], [NIT], [num_tarjeta_C_D], [casilla], [DPI_entrega], [cod_usuario], [cod_autorizador], [cod_sucursal]) VALUES (N'5000803156457', N'50213548-K', N'5088888064', 1006, N'5000803156457', 9, 100, 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (1, N'Recursos Humanos')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (6, N'Registro')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (7, N'Servicio al Cliente')
INSERT [dbo].[Departamentos] ([cod_departamento], [nombre]) VALUES (8, N'Bodega')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (100, N'5000', 1, 1)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (103, N'3000', 6, 14)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (104, N'3000', 6, 15)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (105, N'45000', 8, 16)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (106, N'3000', 6, 17)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (107, N'5000', 7, 18)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (108, N'3000', 8, 19)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (109, N'45000', 1, 20)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (110, N'3000', 6, 21)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (111, N'5000', 7, 22)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (112, N'3000', 8, 23)
INSERT [dbo].[Empleados] ([cod_empleado], [sueldo], [cod_suc_dep], [cod_usuario]) VALUES (113, N'50000', 1, 24)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1013, N'0,2', N'8', N'0,1', N'26/08/2015', N'22:0:44', 17, 100)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1014, N'0,2', N'8', N'0,15', N'26/08/2015', N'22:3:15', 20, 100)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1015, N'0,2', N'8', N'0,1', N'26/08/2015', N'22:4:10', 19, 100)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1016, N'0,2', N'8', N'0,15', N'26/08/2015', N'22:6:36', 20, 100)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1017, N'0,2', N'8', N'0,1', N'26/08/2015', N'22:7:43', 17, 100)
INSERT [dbo].[Facturas] ([cod_factura], [comision], [costo_libra], [impuesto], [fecha], [hora], [cod_paquete], [cod_facturador]) VALUES (1018, N'0,2', N'8', N'0,1', N'26/08/2015', N'22:8:0', 13, 100)
SET IDENTITY_INSERT [dbo].[Facturas] OFF
SET IDENTITY_INSERT [dbo].[Impuestos] ON 

INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (7, N'Accesorio de Telefonia', N'0,15', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (8, N'Accesorio Deportivo', N'0,1', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (9, N'Articulos de Cuero', N'0,15', 1)
INSERT [dbo].[Impuestos] ([cod_impuesto], [categoria], [porcentaje], [habilitado]) VALUES (10, N'Videojuegos', N'0,1', 1)
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

INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (13, N'500', N'2', N'Devuelto', N'5000803156457', 100, 10, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (14, N'1000', N'1', N'EEUU', N'5000803156457', 100, 7, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (15, N'800', N'2', N'Guatemala', N'5000803156457', 100, 10, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (16, N'1500', N'1', N'EEUU', N'5000803156457', 100, 7, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (17, N'400', N'2', N'Devolucion', N'5000803156457', 100, 10, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (18, N'1200', N'1', N'EEUU', N'5000803156451', 100, 7, NULL, 8)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (19, N'200', N'2', N'Guatemala', N'5000803156457', 100, 10, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (20, N'1100', N'1', N'Devuelto', N'5000803156457', 100, 7, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (21, N'1200', N'1', N'Aduana', N'5000803156457', 100, 7, NULL, 9)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (22, N'200', N'2', N'EEUU', N'5000803156451', 100, 10, NULL, 8)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (23, N'1100', N'1', N'EEUU', N'5000803156451', 100, 7, NULL, 8)
INSERT [dbo].[Paquetes] ([cod_paquete], [costo], [libras], [estado], [cod_cliente], [cod_empleado], [cod_impuesto], [cod_pedido], [cod_lote]) VALUES (24, N'800', N'20', N'Guatemala', N'5000803156451', 100, 7, NULL, 8)
SET IDENTITY_INSERT [dbo].[Paquetes] OFF
SET IDENTITY_INSERT [dbo].[SucDep] ON 

INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (1, 1, 1)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (3, 3, 1)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (6, 11, 6)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (7, 12, 7)
INSERT [dbo].[SucDep] ([cod_Suc_Dep], [cod_sucursal], [cod_departamento]) VALUES (8, 12, 8)
SET IDENTITY_INSERT [dbo].[SucDep] OFF
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (1, N'Reforma', N'Guatemala', 50005000, 100, N'0,2', N'8', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (3, N'Terminal', N'Guatemala', 60006000, 80, N'0,2', N'8', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (4, N'Mixco', N'Guatemala', 60006000, 80, N'0,2', N'8', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (5, N'Los Angeles', N'Estados Unidos', 800643251, 20, N'0,2', N'8', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (11, N'Miami FL', N'Estados Unidos', 50000000, 100, N'0', N'0', 1, 1)
INSERT [dbo].[Sucursales] ([cod_sucursal], [nombre], [sede], [telefono], [max_empleados], [comision], [costo_lb], [hcomision], [hcosto_lb]) VALUES (12, N'Ciudad de Guatemala', N'Guatemala', 50000000, 100, N'0', N'0', 1, 1)
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (1, N'100', N'empleado', N'Fern25', N'Juar2', 50505050, N'randy@h', N'50-80', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (9, N'5000803156457', N'5000803156457', N'Fern25', N'Juar2', 50505050, N'randy@h', N'50-80', 4)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (10, N'98', N'admin', N'Fern25', N'Juar2', 50505050, N'randy@h', N'50-80', 1)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (14, N'103', N'empleado', N' Hannah', N'Abbott', 0, N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (15, N'104', N'empleado', N' Hannah', N'Abbott', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (16, N'105', N'empleado', N' Hannah', N'Abbott', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (17, N'106', N'empleado', N' Hannah', N'Abbott', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (18, N'107', N'empleado', N'Juan', N'Chap?n', 0, N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (19, N'108', N'empleado', N'Jos? Luis', N'L?pez Mart?nez', 0, N'correo', N'Guatemala', 2)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (20, N'109', N'empleado', N'John', N'Johnson', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (21, N'110', N'empleado', N'Hannah', N'Abbott', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (22, N'111', N'empleado', N'Juan', N'Chap?n', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (23, N'112', N'empleado', N'Jos? Luis', N'L?pez Mart?nez', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (24, N'113', N'empleado', N'John', N'Johnson', 0, N'correo', N'Guatemala', 3)
INSERT [dbo].[Usuarios] ([cod_usuario], [usuario], [pass], [nombre], [apellidos], [telefono], [correo], [domicilio], [cod_rol]) VALUES (25, N'114', N'empleado', N'tyoss', N'jjo', 0, N'correo', N'Guatemala', 3)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Impuestos]    Script Date: 23/06/2015 1:51:33 ******/
ALTER TABLE [dbo].[Impuestos] ADD  CONSTRAINT [IX_Impuestos] UNIQUE NONCLUSTERED 
(
	[categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
