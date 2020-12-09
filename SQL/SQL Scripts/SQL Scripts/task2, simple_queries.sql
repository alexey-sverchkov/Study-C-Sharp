--- 1.
SELECT TOP (8) * FROM AdventureWorks2017.HumanResources.Department
ORDER BY Name DESC;

--- 2.
SELECT * FROM AdventureWorks2017.HumanResources.Employee
WHERE 
-- case, when year of delta datetime = 22
(SELECT DATEDIFF(YEAR, BirthDate, HireDate) AS DiffDate) = 22 
OR
-- case, when year of rounded to the closest new year HireDate (i.e 2000.06.25 -> 2000.12.31) minus BirthDate = 22
(SELECT DATEDIFF(YEAR, BirthDate, DATEFROMPARTS( YEAR(HireDate), 12, 31 ))) = 22;  

--- 3.
SELECT * FROM AdventureWorks2017.HumanResources.Employee
WHERE MaritalStatus = 'M' 
AND
JobTitle IN ('Design Engineer', 'Tool Designer', 'Engineering Manager', 'Production Control Manager')
ORDER BY BirthDate ASC;


--- 4.
SELECT * FROM AdventureWorks2017.HumanResources.Employee
WHERE DAY(HireDate) = 5 AND MONTH(HireDate) = 3
ORDER BY BusinessEntityID ASC
	OFFSET 1 ROW
	FETCH NEXT 5 ROWS ONLY;

--- 5.
-- change domen 'adventure-works' to 'adventure-works2017'
UPDATE AdventureWorks2017.HumanResources.Employee
SET LoginID = REPLACE(LoginID, 'adventure-works', 'adventure-works2017')
GO
-- print female workers, who were hired at Wednesday
SELECT * FROM AdventureWorks2017.HumanResources.Employee
WHERE Gender = 'F' 
AND
DATEPART(DW, HireDate) = 2;

--- 6.
SELECT * FROM AdventureWorks2017.HumanResources.Employee;
SELECT SUM(VacationHours) AS VacationSumInHours, SUM(SickLeaveHours) AS SicknessSumInHours 
FROM AdventureWorks2017.HumanResources.Employee;

--- 7.
CREATE FUNCTION dbo.getLastWord(@s varchar(100))
returns varchar(200)
as
begin
declare @i int
set @i=len(@s)
 while substring(@s,@i,1)<>' '
  set @i=@i-1
 return substring(@s,@i,len(@s)-@i+1)
end

SELECT TOP(8) JobTitle, dbo.getLastWord(JobTitle) AS LastWord
FROM AdventureWorks2017.HumanResources.Employee
GROUP BY JobTitle
ORDER BY JobTitle DESC;

--- 8.
SELECT * FROM AdventureWorks2017.HumanResources.Employee
WHERE JobTitle LIKE '%Control%';