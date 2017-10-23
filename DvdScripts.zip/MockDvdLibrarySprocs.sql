use MockDvdLibrary
go 

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'InsertDvd'
)

begin 
drop procedure InsertDvd
end 
go 

create procedure InsertDvd(
@DvdId int output,
@Title varchar(250),
@ReleaseYear int,
@Rating varchar(5),
@Director varchar(75),
@Notes varchar(400)
)
as 
	insert into Dvds (Title, ReleaseYear, Rating, Director, Notes)
	values (@Title, @ReleaseYear, @Rating, @Director, @Notes)
	set @DvdId = SCOPE_IDENTITY()

	go

	if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME= 'DvdSelectAll'
)
begin 
drop procedure DvdSelectAll
end 
go 

create procedure DvdSelectAll 
AS
select *
from Dvds D 

GO

if exists(
select* 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'DvdDelete'
)
begin 
drop procedure DvdDelete
end 
go 

create procedure DvdDelete (
@DvdId int
)
As 
	Delete from Dvds
	Where @DvdId = DvdId
go

if exists (
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'UpdateDvd'
)
begin 
drop procedure UpdateDvd
end 
go 

create procedure UpdateDvd (
@DvdId int,
@Title varchar(250),
@ReleaseYear int,
@Rating varchar(5),
@Director varchar(75),
@Notes varchar(400)
)
as 
update Dvds
set Title = @Title,
ReleaseYear = @ReleaseYear,
Rating = @Rating,
Director = @Director,
Notes = @Notes
where DvdId = @DvdId
go 

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetDvdById'
)
begin 
drop procedure GetDvdById
end 
go 

create procedure GetDvdById (
@DvdId int
)
as 
Select *
from Dvds
where DvdId = @DvdId
go

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetDvdsByDirector'
)
begin 
drop procedure GetDvdsByDirector
end 
go 

create procedure GetDvdsByDirector (
@Director varchar(75)
)
AS 
Select *
From Dvds
Where Director = @Director
go 

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetDvdsByRating'
)
begin 
drop procedure GetDvdsByRating
end 
go 

create procedure GetDvdsByRating(
@Rating varchar(5)
)
as 

Select * 
From Dvds
Where Rating = @Rating
go 

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetDvdsByYear'
)
begin 
drop procedure GetDvdsByYear
end 
go 

create procedure GetDvdsByYear(
@ReleaseYear int
)
as 

select * 
From Dvds
Where ReleaseYear = @ReleaseYear
go 

if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetDvdsByTitle'
)
begin 
drop procedure GetDvdsByTitle
end 
go 

create procedure GetDvdsByTitle(
@Title varchar(250)
)
as 

select * 
from Dvds
where Title = @Title
go 


 

