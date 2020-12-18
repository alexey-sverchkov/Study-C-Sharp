---- TASK 4.1

-- 1.
CREATE TABLE dbo.Person(
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
ALTER TABLE dbo.Person
ADD PersonId INT IDENTITY(3, 5) PRIMARY KEY;

-- 3.
ALTER TABLE dbo.Person
ADD CHECK ( MiddleName IN ('J', 'L') );

-- 4.
ALTER TABLE dbo.Person
ADD CONSTRAINT df_Title 
DEFAULT('N/A') FOR Title;

-- 5.
INSERT INTO dbo.Person
SELECT p.BusinessEntityID, p.PersonType, p.NameStyle, p.Title, p.FirstName, 
		p.MiddleName, p.LastName, p.Suffix, p.EmailPromotion, p.ModifiedDate
FROM AdventureWorks2017.HumanResources.Employee AS e
INNER JOIN AdventureWorks2017.Person.Person AS p
ON (e.BusinessEntityID = p.BusinessEntityID)
WHERE (e.JobTitle NOT LIKE 'Finance%' 
AND
p.MiddleName IN ('J', 'L'));

-- print inserted values
SELECT * 
FROM dbo.Person;

-- 6.
ALTER TABLE dbo.Person
ALTER COLUMN Title NVARCHAR(6);
