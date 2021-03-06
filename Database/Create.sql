/****** Object:  Database [Bookshelf]    Script Date: 09/06/2013 15:11:41 ******/
CREATE DATABASE [Bookshelf] 
GO

USE [Bookshelf]
Go

/****** Object:  Table [dbo].[Person]    Script Date: 09/06/2013 15:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Forename] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book]    Script Date: 09/06/2013 15:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Author] [varchar](100) NULL,
	[ISBN] [varchar](15) NULL,
	[AvailableToRent] [bit] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[LenderId] [int] NULL,
	[LendingDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Book_Person_Lender]    Script Date: 09/06/2013 15:11:43 ******/
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Person_Lender] FOREIGN KEY([LenderId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Person_Lender]
GO
/****** Object:  ForeignKey [FK_Book_Person_Owner]    Script Date: 09/06/2013 15:11:43 ******/
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Person_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Person_Owner]
GO
