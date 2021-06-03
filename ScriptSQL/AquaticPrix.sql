USE [AquaticPrix]
GO
/****** Object:  StoredProcedure [dbo].[sp_a_contacto]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_a_contacto](@nombre varchar(100), @asunto varchar(50), @correoElectronico varchar(100), @mensaje varchar(500))as
begin
	insert into Contacto(nombre, asunto, correoElectronico, mensaje, fecha)
	values(@nombre, @asunto, @correoElectronico, @mensaje, GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[sp_a_persona]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_a_persona](@nombre varchar(50), @apellido varchar(50), @correoElectronico varchar(100), @fechaNacimiento date)as
begin
	insert into Persona(nombre, apellido, correoElectronico, fechaNacimiento, fechaAlta)
	values(@nombre, @apellido, @correoElectronico, @fechaNacimiento, GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[sp_a_Uusuario]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_a_Uusuario](@nombreUsuario varchar(50), @clave varchar(100), @estado int)as
begin
	insert into usuario(nombreUsuario, clave, estado)
	values(@nombreUsuario, @clave, @estado)
end
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacto](
	[idContacto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[asunto] [varchar](50) NOT NULL,
	[correoElectronico] [varchar](100) NOT NULL,
	[mensaje] [varchar](500) NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[idContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estadisticas]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estadisticas](
	[idEstadistica] [int] IDENTITY(1,1) NOT NULL,
	[posicion] [int] NOT NULL,
	[perdido] [int] NOT NULL,
	[promedioPartidas] [int] NOT NULL,
	[bajas] [int] NOT NULL,
	[caidas] [int] NOT NULL,
	[promediobaja] [int] NOT NULL,
	[promedioCaidas] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Estadisticas] PRIMARY KEY CLUSTERED 
(
	[idEstadistica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[correoElectronico] [varchar](100) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[fechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[correoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/06/2021 23:51:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[clave] [varchar](100) NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
