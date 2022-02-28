drop table if exists Photos;

create table Photos
(
PhotoID  		int Identity(1,1) Primary Key,
Title			varchar(255),
[Description]	varchar(MAX),
Photo			varbinary(MAX)
);

truncate table Photos;

insert into [Photos] (Title,[Description], Photo ) 
SELECT 
'Apricot 1', 
'Pic of Apricot',
BulkColumn FROM OPENROWSET(BULK N'c:\PNG\2cd43b_ef1ed93217bf4a758a8988748259e7cf_mv2.png', SINGLE_BLOB) image;

insert into [Photos] (Title,[Description], Photo ) 
SELECT 
'Apricot 2', 
'Apricot 2 png',
BulkColumn FROM OPENROWSET(BULK N'c:\PNG\2cd43b_72e222636bef4737a3b3ccde98358e57_mv2.png', SINGLE_BLOB) image;

insert into [Photos] (Title,[Description], Photo ) 
SELECT 
'Apricot 3', 
'Apricot 3 png',
BulkColumn FROM OPENROWSET(BULK N'c:\PNG\2cd43b_620b3bdc917e4d4793b4e3cb5b58e89e_mv2.png', SINGLE_BLOB) image;

select * from Photos

USE [Photo]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 2/28/2022 5:07:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[NationalInsuranceNumber] [varchar](50) COLLATE Latin1_General_BIN2 ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Deterministic, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Photo] [varbinary](max) ENCRYPTED WITH (COLUMN_ENCRYPTION_KEY = [CEK_Auto1], ENCRYPTION_TYPE = Randomized, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256') NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



