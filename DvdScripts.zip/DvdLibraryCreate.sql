use master
GO 

IF exists(select * from sys.databases where name ='DvdLibrary')
drop database DvdLibrary
go 

create database DvdLibrary
go 

use DvdLibrary
go