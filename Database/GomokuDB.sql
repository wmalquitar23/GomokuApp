USE [GomokuDB]
GO
/****** Object:  Table [dbo].[BoardState]    Script Date: 10/10/2023 9:13:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardState](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationX] [int] NULL,
	[LocationY] [int] NULL,
	[OccupiedBy] [varchar](10) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_BoardState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerTurnLog]    Script Date: 10/10/2023 9:13:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerTurnLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlayerTurn] [varchar](10) NULL,
	[DateCreated] [datetime] NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_PlayerTurnLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
