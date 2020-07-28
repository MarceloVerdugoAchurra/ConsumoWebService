USE [XXXXXXXXXXXX]
GO

/****** Object:  Table [dbo].[XXXXXXX]    Script Date: 23-08-2018 19:03:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParametrosPegasus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_vehicle] [varchar](500) NULL,
	[nameParameter] [varchar](500) NULL,
	[valueParameter] [varchar](500) NULL,
	[date] [datetime] NULL,
	[systemTime] [datetime] NULL,
	[eventTime] [datetime] NULL
) ON [PRIMARY]
GO


