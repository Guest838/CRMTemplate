﻿create database NetCoreTemplateDb
alter database NetCoreTemplateDb set recovery simple
go

use NetCoreTemplateDb
go

create table Users
(
	Id int not null identity constraint PK_Users primary key,
	[Login] nvarchar(200) constraint Unique_Users_Login unique not null,
	[Password] nvarchar(max) not null,
	RoleId int not null,
	IsBlocked bit not null,
	RegistrationDate datetime not null,
)

insert into Users values
('admin', 'bcea93fbf1500b9e8e5ae7792c3806f6839fdcc8782f310ae00e08244fc64f09a6bf8c34b5c628cb49ad163c02c1d3959dac0936434ad6f19a4aacd107b82cfb', 1, 0, GETDATE());
go
