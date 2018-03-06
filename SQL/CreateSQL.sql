
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_ActivityType](
	[Dim_ActivityType_ID] [uniqueidentifier] NOT NULL,
	[Dim_ActivityTypeCode] [nvarchar](50) NOT NULL,
	[Dim_ActivityTypeName] [nvarchar](50) NULL,
	[Dim_ActivityTypeDescription] [nvarchar](50) NULL,
	[Dim_ControllingAreaCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dim_ActivityType_1] PRIMARY KEY CLUSTERED 
(
	[Dim_ActivityType_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_ControllingArea]    Script Date: 1/28/2014 8:46:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_ControllingArea](
	[Dim_ControllingAreaCode] [nvarchar](50) NOT NULL,
	[Dim_ControllingAreaName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Dim_ControllingArea] PRIMARY KEY CLUSTERED 
(
	[Dim_ControllingAreaCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_CostCenter]    Script Date: 1/28/2014 8:46:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_CostCenter](
	[Dim_CostCenter_ID] [uniqueidentifier] NOT NULL,
	[Dim_CostCenterCode] [nvarchar](50) NOT NULL,
	[Dim_CostCenterName] [nvarchar](50) NULL,
	[Dim_CostCenterAddressStreet] [nvarchar](50) NULL,
	[Dim_CostCenterAddressCity] [nvarchar](50) NULL,
	[Dim_CostCenterAddressDistrict] [nvarchar](50) NULL,
	[Dim_CostCenterAddressPOBOX] [nvarchar](50) NULL,
	[Dim_CostCenterPersonInCharge] [nvarchar](50) NULL,
	[Dim_ControllingAreaCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dim_CostCenter_1] PRIMARY KEY CLUSTERED 
(
	[Dim_CostCenter_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_Date]    Script Date: 1/28/2014 8:46:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Date](
	[Dim_Date_ID] [int] IDENTITY(1,1) NOT NULL,
	[Dim_Date_FiscalYear] [int] NOT NULL,
	[Dim_Date_Month] [int] NOT NULL,
 CONSTRAINT [PK_Dim_Date] PRIMARY KEY CLUSTERED 
(
	[Dim_Date_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fact_Activity]    Script Date: 1/28/2014 8:46:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_Activity](
	[Fact_Activity_ID] [uniqueidentifier] NOT NULL,
	[Fact_Date_ID] [int] NOT NULL,
	[Fact_CostCenter_ID] [uniqueidentifier] NOT NULL,
	[Fact_ActivityType_ID] [uniqueidentifier] NOT NULL,
	[Fact_CostCenterCode] [nvarchar](50) NULL,
	[Fact_ActivityTypeCode] [nvarchar](50) NULL,
	[Fact_ActivityCurrency] [nvarchar](50) NULL,
	[Fact_ActivityFixPrice] [float] NULL,
	[Fact_ActivityVariablePrice] [float] NULL,
 CONSTRAINT [PK_Fact_Activity_1] PRIMARY KEY CLUSTERED 
(
	[Fact_Activity_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Dim_ActivityType]  WITH CHECK ADD  CONSTRAINT [FK_Dim_ActivityType_Dim_ControllingArea] FOREIGN KEY([Dim_ControllingAreaCode])
REFERENCES [dbo].[Dim_ControllingArea] ([Dim_ControllingAreaCode])
GO
ALTER TABLE [dbo].[Dim_ActivityType] CHECK CONSTRAINT [FK_Dim_ActivityType_Dim_ControllingArea]
GO
ALTER TABLE [dbo].[Dim_CostCenter]  WITH CHECK ADD  CONSTRAINT [FK_Dim_CostCenter_Dim_CostCenter] FOREIGN KEY([Dim_ControllingAreaCode])
REFERENCES [dbo].[Dim_ControllingArea] ([Dim_ControllingAreaCode])
GO
ALTER TABLE [dbo].[Dim_CostCenter] CHECK CONSTRAINT [FK_Dim_CostCenter_Dim_CostCenter]
GO
ALTER TABLE [dbo].[Fact_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Fact_Activity_Dim_ActivityType] FOREIGN KEY([Fact_ActivityType_ID])
REFERENCES [dbo].[Dim_ActivityType] ([Dim_ActivityType_ID])
GO
ALTER TABLE [dbo].[Fact_Activity] CHECK CONSTRAINT [FK_Fact_Activity_Dim_ActivityType]
GO
ALTER TABLE [dbo].[Fact_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Fact_Activity_Dim_CostCenter] FOREIGN KEY([Fact_CostCenter_ID])
REFERENCES [dbo].[Dim_CostCenter] ([Dim_CostCenter_ID])
GO
ALTER TABLE [dbo].[Fact_Activity] CHECK CONSTRAINT [FK_Fact_Activity_Dim_CostCenter]
GO
ALTER TABLE [dbo].[Fact_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Fact_Activity_Dim_Date] FOREIGN KEY([Fact_Date_ID])
REFERENCES [dbo].[Dim_Date] ([Dim_Date_ID])
GO
ALTER TABLE [dbo].[Fact_Activity] CHECK CONSTRAINT [FK_Fact_Activity_Dim_Date]
GO

