use MockDvdLibrary
go 
if exists(
select * 
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'DbReset'
)
drop procedure DbReset
go 

create procedure DbReset 
as 
begin 
	delete from Dvds;

	dbcc checkident(Dvds, reseed, 1)
set identity_insert Dvds ON 

insert into Dvds (DvdId, Title, ReleaseYear, Rating, Director, Notes)
values (1, 'Braveheart', 1995, 'R', 'Mel Gibson', 'Winner of best picture in 1995.'), 
		(2, 'Star Wars', 1977, 'PG', 'George Lucas', 'A long, long time ago...'),
		(3, 'Indiana Jones: Raiders of the Lost Ark', 1981, 'PG', 'Steven Spielberg', 'A classic movie.' ),
		(4, 'Batman: Dark Knight', 2008, 'PG-13', 'Christopher Nolan', 'Great flick'),
		(5, 'Batman: Dark Knight Rises', 2012, 'PG-13', 'Christopher Nolan', 'Solid movie.')
set identity_insert Dvds OFF 
end