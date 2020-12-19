-- 1.
CREATE TABLE dbo.Person_New(
	BusinessEntityID INT,
	PersonType		 NCHAR(2),
	NameStyle		 BIT,
	Title			 NVARCHAR(8),
	FirstName		 NVARCHAR(50),
	MiddleName		 NVARCHAR(50),
	LastName		 NVARCHAR(50),
	Suffix			 NVARCHAR(10),
	EmailPromotion   INT,
	ModifiedDate	 DATETIME
);

-- 2.
ALTER TABLE dbo.Person_New
ADD Salutation NVARCHAR(80);

-- 3.
INSERT INTO dbo.Person_New (BusinessEntityID, PersonType, NameStyle, Title, FirstName, 
							MiddleName, LastName, Suffix, EmailPromotion, ModifiedDate)
SELECT p.BusinessEntityID, p.PersonType, p.NameStyle, 
		(CASE
			WHEN e.Gender = 'M'
				THEN 'Mr.'
			WHEN e.Gender = 'F'
				THEN 'Ms.'
			ELSE NULL
		END) AS Title, 
		p.FirstName, p.MiddleName, p.LastName, p.Suffix, p.EmailPromotion, p.ModifiedDate
FROM dbo.Person AS p
INNER JOIN 
AdventureWorks2017.HumanResources.Employee AS e
ON (p.BusinessEntityID = e.BusinessEntityID);

-- print new table
SELECT * FROM dbo.Person_New;

-- 4.
UPDATE dbo.Person_New
SET Salutation = Title + ' ' + FirstName;

SELECT * FROM dbo.Person_New;

-- 5.
DELETE FROM dbo.Person_New
WHERE LEN(Salutation) > 10;

SELECT * FROM dbo.Person_New;

-- 6.

-- to see all constraints
sp_help Person; 

ALTER TABLE dbo.Person
DROP CONSTRAINT df_Title;

ALTER TABLE dbo.Person
DROP CONSTRAINT CK__Person__MiddleNa__4BCC3ABA;

ALTER TABLE dbo.Person
DROP CONSTRAINT PK__Person__AA2FFBE50BD07E9C;

-- 7.
ALTER TABLE dbo.Person
DROP COLUMN PersonID;

SELECT * FROM dbo.Person;

-- 8.
DROP TABLE dbo.Person;
DROP TABLE dbo.Person_New;