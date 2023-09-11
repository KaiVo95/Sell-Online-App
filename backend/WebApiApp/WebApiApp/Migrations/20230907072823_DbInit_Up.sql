/****
=============================================
Requested by: Kai
Create date: 07-09-2023
Description: Create init database
=============================================
****/

-- 1. Create new table: Admin
CREATE TABLE [dbo].[Admin](
	[AdminId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL DEFAULT '',
	[PassWord] [nvarchar](250) NOT NULL DEFAULT '',
	[FullName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)) 
GO

-- 2. Create new table: User
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](250) NOT NULL,
	[FullName] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)
	) 
GO

-- 3. Create new table: Category
CREATE TABLE [dbo].[Category](
	[CategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] bigint NOT NULL DEFAULT '0',
	[SortOrder] int NOT NULL DEFAULT '0',
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)
	)  
GO

-- 4. Create new table: Product
CREATE TABLE [dbo].[Product](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] numeric(18,2) NOT NULL,
	[Content] text NOT NULL,
	[Discount] int NOT NULL,
	[ImageLink] [nvarchar](50) NOT NULL,
	[ImageList] text NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL DEFAULT '0',
	[View] int NOT NULL DEFAULT '0',
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)
	) 
GO

-- 5. Create new table: Transaction
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[Status] int NOT NULL DEFAULT '0',
	[UserId] [bigint] NOT NULL DEFAULT '0',
	[UserName] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserPhone] [nvarchar](20) NOT NULL,
	[Amount] numeric(18,2) NOT NULL,
	[Payment] [nvarchar](32) NOT NULL,
	[PaymentInfo] text NOT NULL,
	[Security] [nvarchar](16) NOT NULL,
	[Created] [datetimeoffset](7) NOT NULL DEFAULT '0',
	CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)
	) 
GO

-- 6. Create new table: Order
CREATE TABLE [dbo].[Order](
	[OrderId] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Qty] int NOT NULL DEFAULT '0',
	[Amount] numeric(18,2) NOT NULL,
	[Data] text NOT NULL,
	[Status] int NOT NULL DEFAULT '0',
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)
	) 
GO

-- 7. Create FOREIGN KEY for table Product
ALTER TABLE Product ADD CONSTRAINT fk_Product FOREIGN KEY(CategoryId) REFERENCES Category(CategoryId)

-- 8. Create FOREIGN KEY for table Transaction
ALTER TABLE [dbo].[Transaction] ADD CONSTRAINT fk_Transaction FOREIGN KEY(UserId) REFERENCES  [dbo].[User](UserId)

-- 9. Create FOREIGN KEY for table Order
ALTER TABLE [dbo].[Order] ADD CONSTRAINT fk01_Order FOREIGN KEY(TransactionId) REFERENCES  [dbo].[Transaction](TransactionId)
ALTER TABLE [dbo].[Order] ADD CONSTRAINT fk02_Order FOREIGN KEY(ProductId) REFERENCES  [dbo].[Product](ProductId)