use master
GO 

IF exists(select * from sys.databases where name ='MockDvdLibrary')
drop database MockDvdLibrary
go 

create database MockDvdLibrary
go 

use DvdLibrary
go