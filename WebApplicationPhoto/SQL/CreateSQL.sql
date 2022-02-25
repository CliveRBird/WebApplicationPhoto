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