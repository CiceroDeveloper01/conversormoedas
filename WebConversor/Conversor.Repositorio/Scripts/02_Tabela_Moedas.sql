USE [dbConversor]
GO

/****** Object:  Table [dbo].[Moedas]    Script Date: 24/11/2020 10:47:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Moedas](
	[Moeda] [varchar](50) NOT NULL,
	[DataInicio] [date] NOT NULL,
	[DataFim] [date] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]
GO


