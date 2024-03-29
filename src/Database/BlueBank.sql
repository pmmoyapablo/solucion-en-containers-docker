USE [master]
GO

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'BlueBank')
BEGIN
CREATE DATABASE [BlueBank]
 CONTAINMENT = NONE
 ON PRIMARY
 ( NAME = N'BlueBank', FILENAME = N'/var/opt/mssql/data/BlueBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON
 ( NAME = N'BlueBank_log', FILENAME = N'/var/opt/mssql/data/BlueBank_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO
 
USE [BlueBank]
GO
/****** Object:  Table [dbo].[Acounts]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acounts](
	[Code] [varchar](16) NOT NULL,
	[CustomerID] [nchar](5) NOT NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_Acounts] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [nchar](5) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Acounts] ([Code], [CustomerID], [Amount]) VALUES (N'10234968756', N'32343', 1500.0000)
INSERT [dbo].[Acounts] ([Code], [CustomerID], [Amount]) VALUES (N'65948577382', N'89087', 340.0000)
INSERT [dbo].[Acounts] ([Code], [CustomerID], [Amount]) VALUES (N'67886377950', N'11121', 0.0000)
INSERT [dbo].[Acounts] ([Code], [CustomerID], [Amount]) VALUES (N'78939200013', N'12345', 100.0000)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'10002', N'Maria Anders', N'Sales Representative', N'Obere Str. 57', N'Berlin', NULL, N'12209', N'Germany', N'030-0074321', N'030-0076545')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'10004', N'Ana Trujillo', N'Owner', N'Avda. de la Constitución 2222', N'México D.F.', NULL, N'05021', N'Mexico', N'(5) 555-4729', N'(5) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'10029', N'Carine Schmitt', N'Marketing Manager', N'54, rue Royale', N'Nantes', NULL, N'44000', N'France', N'40.32.21.21', N'40.32.21.20')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'10394', N'Elizabeth Brown', N'Sales Representative', N'Berkeley Gardens 12  Brewery', N'London', NULL, N'WX1 6LT', N'UK', N'(171) 555-2282', N'(171) 555-9199')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'11121', N'Ann Devon', N'Sales Agent', N'35 King George', N'London', NULL, N'WX3 6FW', N'UK', N'(171) 555-0297', N'(171) 555-3373')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'12345', N'Hanna Moos', N'Sales Representative', N'Forsterstr. 57', N'Mannheim', NULL, N'68306', N'Germany', N'0621-08460', N'0621-08924')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'12389', N'Laurence Lebihan', N'Owner', N'12, rue des Bouchers', N'Marseille', NULL, N'13008', N'France', N'91.24.45.40', N'91.24.45.41')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'14354', N'Yang Wang', N'Owner', N'Hauptstr. 29', N'Bern', NULL, N'3012', N'Switzerland', N'0452-076545', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'17689', N'Martine Rancé', N'Assistant Sales Agent', N'184, chaussée de Tournai', N'Lille', NULL, N'59000', N'France', N'20.16.10.16', N'20.16.10.17')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'20912', N'Antonio Moreno', N'Owner', N'Mataderos  2312', N'México D.F.', NULL, N'05023', N'Mexico', N'(5) 555-3932', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'23143', N'Frédérique Citeaux', N'Marketing Manager', N'24, place Kléber', N'Strasbourg', NULL, N'67000', N'France', N'88.60.15.31', N'88.60.15.32')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'23454', N'Sven Ottlieb', N'Order Administrator', N'Walserweg 21', N'Aachen', NULL, N'52066', N'Germany', N'0241-039123', N'0241-059428')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'23478', N'Victoria Ashworth', N'Sales Representative', N'Fauntleroy Circus', N'London', NULL, N'EC2 5NT', N'UK', N'(171) 555-1212', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'30001', N'Pedro Afonso', N'Sales Associate', N'Av. dos Lusíadas, 23', N'Sao Paulo', N'SP', N'05432-043', N'Brazil', N'(11) 555-7647', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'32121', N'Thomas Hardy', N'Sales Representative', N'120 Hanover Sq.', N'London', NULL, N'WA1 1DP', N'UK', N'(171) 555-7788', N'(171) 555-6750')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'32343', N'Roland Mendel', N'Sales Manager', N'Kirchgasse 6', N'Graz', NULL, N'8010', N'Austria', N'7675-3425', N'7675-3426')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'33321', N'Janine Labrune', N'Owner', N'67, rue des Cinquante Otages', N'Nantes', NULL, N'44000', N'France', N'40.67.88.88', N'40.67.89.89')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'34254', N'Martín Sommer', N'Owner', N'C/ Araquil, 67', N'Madrid', NULL, N'28023', N'Spain', N'(91) 555 22 82', N'(91) 555 91 99')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'34590', N'Diego Roel', N'Accounting Manager', N'C/ Moralzarzal, 86', N'Madrid', NULL, N'28034', N'Spain', N'(91) 555 94 44', N'(91) 555 55 93')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'36780', N'Peter Franken', N'Marketing Manager', N'Berliner Platz 43', N'München', NULL, N'80805', N'Germany', N'089-0877310', N'089-0877451')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'54930', N'Elizabeth Lincoln', N'Accounting Manager', N'23 Tsawassen Blvd.', N'Tsawassen', N'BC', N'T2F 8M4', N'Canada', N'(604) 555-4729', N'(604) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'76509', N'Francisco Chang', N'Marketing Manager', N'Sierras de Granada 9993', N'México D.F.', NULL, N'05022', N'Mexico', N'(5) 555-3392', N'(5) 555-7293')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'87643', N'Patricio Simpson', N'Sales Agent', N'Cerrito 333', N'Buenos Aires', NULL, N'1010', N'Argentina', N'(1) 135-5555', N'(1) 135-4892')
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'89087', N'Aria Cruz', N'Marketing Assistant', N'Rua Orós, 92', N'Sao Paulo', N'SP', N'05442-030', N'Brazil', N'(11) 555-9857', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'90876', N'Maria Larsson', N'Owner', N'Åkergatan 24', N'Bräcke', NULL, N'S-844 67', N'Sweden', N'0695-34 67 21', NULL)
INSERT [dbo].[Customers] ([CustomerID], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax]) VALUES (N'90987', N'Christina Berglund', N'Order Administrator', N'Berguvsvägen  8', N'Luleå', NULL, N'S-958 22', N'Sweden', N'0921-12 34 65', N'0921-12 34 67')
ALTER TABLE [dbo].[Acounts]  WITH NOCHECK ADD  CONSTRAINT [FK_Acounts_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Acounts] CHECK CONSTRAINT [FK_Acounts_Customers]
GO
/****** Object:  StoredProcedure [dbo].[AcountsGet]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AcountsGet]
(
    @Code nvarchar (16) 
)
AS
BEGIN
    SELECT Code, CustomerID, Amount FROM Acounts WHERE Code = @Code
END

GO
/****** Object:  StoredProcedure [dbo].[AcountsInsert]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AcountsInsert]
(
    @Code nvarchar (16) ,
	@CustomerID nchar (5) ,
	@Amount money
)
AS
BEGIN

    INSERT INTO Acounts (Code, CustomerID, Amount)
    VALUES(@Code, @CustomerID, @Amount)

END

GO
/****** Object:  StoredProcedure [dbo].[AcountsMove]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AcountsMove]
(
    @Code nvarchar (16) ,
	@Amount money
)
AS
BEGIN

    UPDATE Acounts SET Amount = @Amount
    WHERE Code = @Code;

END

GO
/****** Object:  StoredProcedure [dbo].[CustomersList]    Script Date: 17/5/2021 4:14:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CustomersList]
AS
BEGIN

    SELECT CustomerID, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax
    FROM Customers

END

GO