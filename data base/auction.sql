USE [master]
GO
/****** Object:  Database [Auction]    Script Date: 6/10/2016 3:56:03 PM ******/
CREATE DATABASE [Auction]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Auction', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Auction.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Auction_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Auction_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Auction] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Auction].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Auction] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Auction] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Auction] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Auction] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Auction] SET ARITHABORT OFF 
GO
ALTER DATABASE [Auction] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Auction] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Auction] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Auction] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Auction] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Auction] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Auction] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Auction] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Auction] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Auction] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Auction] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Auction] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Auction] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Auction] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Auction] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Auction] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Auction] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Auction] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Auction] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Auction] SET  MULTI_USER 
GO
ALTER DATABASE [Auction] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Auction] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Auction] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Auction] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Auction]
GO
/****** Object:  StoredProcedure [dbo].[add_description]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_description]
	@id int,
	@text nvarchar(250)
AS
BEGIN
	INSERT dbo.[description_product] (id,[text])
	VALUES (@id,@text)
END

GO
/****** Object:  StoredProcedure [dbo].[add_image_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_image_product] 
	@id int,
	@image varbinary(max),
	@content_type nvarchar(50)
AS
BEGIN
	INSERT dbo.images_product(id,[image],content_type)
	VALUES (@id,@image,@content_type)
END

GO
/****** Object:  StoredProcedure [dbo].[add_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_product]
	@name nvarchar(50),
	@current_rate money,
	@completion date
AS
BEGIN
	INSERT dbo.product(name,current_rate,completion)
	VALUES(@name,@current_rate,@completion)
	SELECT scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[add_rate]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[add_rate]
@id_user int,
@id_product int,
@rate money
AS
BEGIN
	DELETE dbo.user_rate 
	WHERE dbo.user_rate.id_product = @id_product

	INSERT dbo.user_rate(id_user,id_product,rate)
	VALUES(@id_user,@id_product,@rate)
END

GO
/****** Object:  StoredProcedure [dbo].[add_user_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_user_product]
@id_user int,
@id_product int
AS
BEGIN
	INSERT dbo.products_app_user (id_user, id_product)
	VALUES (@id_user, @id_product)
END

GO
/****** Object:  StoredProcedure [dbo].[add_user_role]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_user_role]
@id_user int, 
@id_role int
AS
BEGIN
	INSERT app_user_role(id_user,id_role)
	VALUES(@id_user,@id_role)
END

GO
/****** Object:  StoredProcedure [dbo].[app_user_add]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[app_user_add]
	@login nvarchar(50),
	@password varbinary(50)
AS
BEGIN
	INSERT INTO  dbo.[app_user] (login, password)
	 VALUES(@login, @password)
END

GO
/****** Object:  StoredProcedure [dbo].[app_user_get]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[app_user_get]
	@login nvarchar(50)
AS
BEGIN
	SELECT u.[password] FROM app_user as u
	WHERE u.[login] = @login
END

GO
/****** Object:  StoredProcedure [dbo].[delete_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_product]
	@id int
AS
BEGIN
	DELETE product
	WHERE product.id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[get_app_user]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_app_user]
AS
BEGIN
  SELECT a.id, a.login FROM app_user as a
END

GO
/****** Object:  StoredProcedure [dbo].[get_description]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_description]
	@id int
AS
BEGIN
	SELECT p.[text] FROM dbo.[description_product] as p
	WHerE p.id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[get_id]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_id]
@login nvarchar(50)
AS
BEGIN
	SELECT u.[id] FROM app_user as u
	WHERE u.[login] = @login
END

GO
/****** Object:  StoredProcedure [dbo].[get_login]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_login]
AS
BEGIN
	SELECT u.[login] FROM app_user as u
END

GO
/****** Object:  StoredProcedure [dbo].[get_my_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_my_product]
@id_user int
AS
BEGIN
	SELECT p.id, p.name, p.current_rate,p.completion FROM product as p
	INNER JOIN products_app_user
		ON p.id = products_app_user.id_product
	WHERE products_app_user.id_user = @id_user
END

GO
/****** Object:  StoredProcedure [dbo].[get_products]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[get_products]
AS
BEGIN
	SELECT id,name,current_rate,completion FROM product
END

GO
/****** Object:  StoredProcedure [dbo].[get_roles]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_roles]
AS
BEGIN
  SELECT a.id, a.name FROM role as a
END

GO
/****** Object:  StoredProcedure [dbo].[get_user_lots]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[get_user_lots]
@id_user int
AS
BEGIN
	SELECT p.id, p.name, p.current_rate,p.completion FROM product as p
	INNER JOIN user_rate
		ON p.id = user_rate.id_product
	WHERE user_rate.id_user = @id_user
END

GO
/****** Object:  StoredProcedure [dbo].[get_user_role]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_user_role]
@id_user int
AS
BEGIN
  SELECT r.name FROM role AS r
  INNER JOIN app_user_role
  ON r.id = app_user_role.id_role
  WHERE app_user_role.id_user = @id_user
END

GO
/****** Object:  StoredProcedure [dbo].[get_user_roleFull]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_user_roleFull]
@id_user int
AS
BEGIN
  SELECT r.name,r.id FROM role AS r
  INNER JOIN app_user_role
  ON r.id = app_user_role.id_role
  WHERE app_user_role.id_user = @id_user
END

GO
/****** Object:  StoredProcedure [dbo].[GetByid_image_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetByid_image_product]
	@id int
AS
BEGIN
	SELECT p.content_type, p.[image] FROM images_product as p
	WHERE p.id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[update_product_description]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
CREATE PROCEDURE [dbo].[update_product_description]
@id int,
@description nvarchar(250)
AS
BEGIN
	UPDATE description_product 
	SET description_product.[text] = @description
	WHERE description_product.id = @id
END


GO
/****** Object:  StoredProcedure [dbo].[update_product_rate]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[update_product_rate]
@id int,
@rate money
AS
BEGIN
	UPDATE product 
	SET product.current_rate = @rate
	WHERE product.id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[user_delete_role]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[user_delete_role]
@id_user int,
@id_role int
AS
BEGIN
  DELETE app_user_role
  WHERE app_user_role.id_role = @id_role AND  app_user_role.id_user = @id_user
END

GO
/****** Object:  Table [dbo].[app_user]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[app_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [varbinary](50) NOT NULL,
 CONSTRAINT [PK_app_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[app_user_role]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app_user_role](
	[id_user] [int] NOT NULL,
	[id_role] [int] NOT NULL,
 CONSTRAINT [PK_app_user_role] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[description_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[description_product](
	[id] [int] NOT NULL,
	[text] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_description_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[images_product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[images_product](
	[id] [int] NOT NULL,
	[image] [varbinary](max) NOT NULL,
	[content_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_images_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[current_rate] [money] NOT NULL,
	[completion] [date] NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[products_app_user]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_app_user](
	[id_user] [int] NOT NULL,
	[id_product] [int] NOT NULL,
 CONSTRAINT [PK_products_app_user] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[role]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_rate]    Script Date: 6/10/2016 3:56:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_rate](
	[id_product] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[rate] [money] NOT NULL,
 CONSTRAINT [PK_user_rate] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC,
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[app_user_role]  WITH CHECK ADD  CONSTRAINT [FK_app_user_role_app_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[app_user] ([id])
GO
ALTER TABLE [dbo].[app_user_role] CHECK CONSTRAINT [FK_app_user_role_app_user]
GO
ALTER TABLE [dbo].[app_user_role]  WITH CHECK ADD  CONSTRAINT [FK_app_user_role_role] FOREIGN KEY([id_user])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[app_user_role] CHECK CONSTRAINT [FK_app_user_role_role]
GO
ALTER TABLE [dbo].[description_product]  WITH CHECK ADD  CONSTRAINT [FK_description_product_product] FOREIGN KEY([id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[description_product] CHECK CONSTRAINT [FK_description_product_product]
GO
ALTER TABLE [dbo].[images_product]  WITH CHECK ADD  CONSTRAINT [FK_images_product_product] FOREIGN KEY([id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[images_product] CHECK CONSTRAINT [FK_images_product_product]
GO
ALTER TABLE [dbo].[products_app_user]  WITH CHECK ADD  CONSTRAINT [FK_products_app_user_app_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[app_user] ([id])
GO
ALTER TABLE [dbo].[products_app_user] CHECK CONSTRAINT [FK_products_app_user_app_user]
GO
ALTER TABLE [dbo].[products_app_user]  WITH CHECK ADD  CONSTRAINT [FK_products_app_user_product] FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[products_app_user] CHECK CONSTRAINT [FK_products_app_user_product]
GO
ALTER TABLE [dbo].[user_rate]  WITH CHECK ADD  CONSTRAINT [FK_user_rate_app_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[app_user] ([id])
GO
ALTER TABLE [dbo].[user_rate] CHECK CONSTRAINT [FK_user_rate_app_user]
GO
ALTER TABLE [dbo].[user_rate]  WITH CHECK ADD  CONSTRAINT [FK_user_rate_product] FOREIGN KEY([id_product])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[user_rate] CHECK CONSTRAINT [FK_user_rate_product]
GO
USE [master]
GO
ALTER DATABASE [Auction] SET  READ_WRITE 
GO
