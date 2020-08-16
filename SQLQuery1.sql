use ldb;
create table WinningAtWalmart_Workers
([Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[FirstName] varchar(50) not null,
[LastName] varchar(50) not null,
[Email] varchar(50) not null,
[Password] varchar(50) not null)