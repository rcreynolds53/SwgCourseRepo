USE master
GO
 
CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

use DvdLibrary
go 

create user DvdLibraryApp for login DvdLibraryApp
go

grant execute on DbReset to DvdLibraryApp
grant execute on DvdDelete to DvdLibraryApp
grant execute on DvdSelectAll to DvdLibraryApp
grant execute on GetDvdById to DvdLibraryApp
grant execute on GetDvdsByDirector to DvdLibraryApp
grant execute on GetDvdsByRating to DvdLibraryApp
grant execute on GetDvdsByTitle to DvdLibraryApp
grant execute on GetDvdsByYear to DvdLibraryApp
grant execute on InsertDvd to DvdLibraryApp
grant execute on UpdateDvd to DvdLibraryApp
go

GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO