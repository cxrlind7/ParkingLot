USE [autos]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 21/04/2022 16:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 21/04/2022 16:19:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[isInside] [tinyint] NULL,
	[costoTotal] [int] NULL,
	[id_registro] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](30) NULL,
	[Entrada] [varchar](30) NULL,
	[Salida] [varchar](30) NULL,
	[Tipo] [varchar](30) NULL
) ON [PRIMARY]
GO
