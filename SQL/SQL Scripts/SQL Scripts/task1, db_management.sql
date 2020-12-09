/*CREATE DATABASE AdventureWorks2017;*/

CREATE DATABASE Something;

SELECT name, crdate AS creation_date 
FROM sys.sysdatabases 
WHERE name='Something';

CREATE TABLE Something.dbo.Wicked(
	Id INT NOT NULL
);

BACKUP DATABASE Something
TO DISK = 'D:\backups\Something.bak';

DROP DATABASE Something;

RESTORE DATABASE Something
FROM DISK = 'D:\backups\Something.bak';