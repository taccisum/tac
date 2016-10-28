USE [MvcDemo]
GO

/****** Object:  Table [dbo].[PageBrowseHistory]    Script Date: 2016/10/28 15:10:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PageBrowseHistory](
	[ID] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[UrlReferrer] [varchar](1024) NOT NULL,
	[Url] [varchar](1024) NOT NULL,
	[RelativeMenuId] [uniqueidentifier] NULL,
	[IsAjaxRequest] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PageBrowseHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PageBrowseHistory] ADD  DEFAULT ((0)) FOR [IsAjaxRequest]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ҳ����û�id��null��ʾ�ο�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PageBrowseHistory', @level2type=N'COLUMN',@level2name=N'UserId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����Ĳ˵�id��null��ʾ�û������ҳ��δ��ӵ�ϵͳ�˵���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PageBrowseHistory', @level2type=N'COLUMN',@level2name=N'RelativeMenuId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ͨ��ajax�����ҳ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PageBrowseHistory', @level2type=N'COLUMN',@level2name=N'IsAjaxRequest'
GO


