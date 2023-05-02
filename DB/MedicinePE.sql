USE [MedicinePE]
GO
/****** Object:  Table [dbo].[Medicine_Evaluation]    Script Date: 2023/5/2 17:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine_Evaluation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[EvaluationName] [nvarchar](50) NULL,
	[EvaluationType] [int] NULL,
	[Score] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_EvaluationCover] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine_Project]    Script Date: 2023/5/2 17:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine_Project](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EvaluationId] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[AnswerA] [nvarchar](max) NULL,
	[AnswerB] [nvarchar](max) NULL,
	[AnswerC] [nvarchar](max) NULL,
	[AnswerD] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[ScoreA] [int] NULL,
	[ScoreB] [int] NULL,
	[ScoreC] [int] NULL,
	[ScoreD] [int] NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Medicine_Project] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine_Record]    Script Date: 2023/5/2 17:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine_Record](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Score] [int] NULL,
	[EvaluationId] [int] NULL,
 CONSTRAINT [PK_Medicine_Record] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine_Users]    Script Date: 2023/5/2 17:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine_Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserAccount] [nvarchar](50) NULL,
	[UserPwd] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserGander] [int] NULL,
	[UserAge] [int] NULL,
	[Education] [int] NULL,
	[Marriage] [int] NULL,
	[UserType] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Medicine_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Medicine_Evaluation] ADD  CONSTRAINT [DF_EvaluationCover_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Medicine_Project] ADD  CONSTRAINT [DF_Medicine_Project_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Medicine_Record] ADD  CONSTRAINT [DF_Medicine_Record_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Medicine_Users] ADD  CONSTRAINT [DF_Medicine_Users_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：普通用户，2：超级用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Medicine_Users', @level2type=N'COLUMN',@level2name=N'UserType'
GO
