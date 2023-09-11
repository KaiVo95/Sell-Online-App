/****
=============================================
Requested by: Kai
Create date: 07-09-2023
Description: Create RefreshToken Table
=============================================
****/

-- 1. Create new table: RefreshToken
CREATE TABLE [dbo].[RefreshToken](
	[RefreshTokenId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] bigint NOT NULL,
	[Token] [nvarchar](max),
	[JwtId] [nvarchar](max),
	[IsUsed] bit NOT NULL,
	[IsRevoked] bit NOT NULL,
	[IssuedAt] [datetimeoffset](7) NOT NULL,
	[ExpireAt] [datetimeoffset](7) NOT NULL,
	CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED 
(
	[RefreshTokenId] ASC
)) 
GO

-- 2. Create FOREIGN KEY for table RefreshToken
ALTER TABLE RefreshToken ADD CONSTRAINT fk_RefreshToken FOREIGN KEY(UserId) REFERENCES [dbo].[User](UserId)