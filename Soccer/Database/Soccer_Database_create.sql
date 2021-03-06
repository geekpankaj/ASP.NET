USE [Soccer]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 2018-04-24 11:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[Registration_Number] [int] NOT NULL,
	[Club_Name] [char](50) NOT NULL,
	[Club_City] [char](50) NOT NULL,
	[Address] [char](100) NOT NULL,
	[Club_Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Club_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 2018-04-24 11:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Match_id] [int] IDENTITY(701,1) NOT NULL,
	[HostClub] [varchar](50) NOT NULL,
	[GuestClub] [varchar](50) NOT NULL,
	[Date_schedule] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Match_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 2018-04-24 11:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Player_Id] [int] IDENTITY(100,1) NOT NULL,
	[Player_Name] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Jercy_No] [int] NOT NULL,
	[Club_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Player_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [Club_Id] FOREIGN KEY([Club_Id])
REFERENCES [dbo].[Club] ([Club_Id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [Club_Id]
GO
