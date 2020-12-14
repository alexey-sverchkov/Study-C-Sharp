--- 1.
SELECT Employee.BusinessEntityID,
	   Employee.JobTitle,
	   SortedEmployeePayHistory.Rate AS MaxRate
FROM AdventureWorks2017.HumanResources.Employee
INNER JOIN 
-- create subtable from EmployeePayHistory, which contains only max rate for every EntityID
(SELECT BusinessEntityID, MAX(Rate) AS Rate
FROM AdventureWorks2017.HumanResources.EmployeePayHistory
GROUP BY BusinessEntityID) SortedEmployeePayHistory
-- join condition
ON (Employee.BusinessEntityID = SortedEmployeePayHistory.BusinessEntityID);

--- 2.
SELECT Employee.BusinessEntityID, Employee.JobTitle, EmployeePayHistory.Rate,
-- this function returns the rank of each row within a result set partition
DENSE_RANK() OVER
(ORDER BY EmployeePayHistory.Rate ASC) AS RateRank
FROM AdventureWorks2017.HumanResources.Employee
INNER JOIN 
AdventureWorks2017.HumanResources.EmployeePayHistory
ON (Employee.BusinessEntityID = EmployeePayHistory.BusinessEntityID);

--- 3.
-- get temp subtable from EmployeePayHistory, which includes only ID of employees (with number of changes), who's hourly rate changed at least 1 time
SELECT BusinessEntityID, COUNT(BusinessEntityID) as RateCount 
INTO EmployeesWithVariableHourlyRates
FROM AdventureWorks2017.HumanResources.EmployeePayHistory
GROUP BY BusinessEntityID
HAVING COUNT(BusinessEntityID) > 1;

SELECT Employee.BusinessEntityID, Employee.JobTitle, EmployeesWithVariableHourlyRates.RateCount
FROM AdventureWorks2017.HumanResources.Employee
INNER JOIN
EmployeesWithVariableHourlyRates
ON(Employee.BusinessEntityID = EmployeesWithVariableHourlyRates.BusinessEntityID)

-- delete temp table
DROP TABLE EmployeesWithVariableHourlyRates;

--- 4.
-- get temp subtable from EmployeeDeparmentHistory, which includes department id and number of employees in every department
SELECT EmployeeDepartmentHistory.DepartmentID, COUNT(EmployeeDepartmentHistory.BusinessEntityID) AS EmployeeCount
INTO NumberOfEmployeesInDepartments
FROM AdventureWorks2017.HumanResources.EmployeeDepartmentHistory
WHERE EndDate IS NULL
GROUP BY DepartmentID;

SELECT NumberOfEmployeesInDepartments.DepartmentID, Department.Name, NumberOfEmployeesInDepartments.EmployeeCount
FROM NumberOfEmployeesInDepartments
INNER JOIN
AdventureWorks2017.HumanResources.Department
ON(NumberOfEmployeesInDepartments.DepartmentID = Department.DepartmentID)

-- delete temp table
DROP TABLE NumberOfEmployeesInDepartments;

--- 5.
SELECT eph.BusinessEntityID, e.JobTitle, eph.Rate,
-- a) use PARTITION BY to group rows
-- b) use LAG on row to get previous row (in this situation for every rate we get previous rate, if they belong to the same person)
-- c) use ORDER BY RateChangeDate to get ascending dates (to get rates in chronological order)
ISNULL(LAG(eph.Rate) OVER(PARTITION BY eph.BusinessEntityID
				ORDER BY eph.RateChangeDate), 0) AS PrevRate,
-- Remark: can't use the alias of a column in the SELECT list (so we can't say (Rate - PrevRate) as DiffRate)
(eph.Rate - (ISNULL(LAG(eph.Rate) OVER(PARTITION BY eph.BusinessEntityID
				ORDER BY eph.RateChangeDate), 0))) AS DiffRate
FROM AdventureWorks2017.HumanResources.EmployeePayHistory AS eph
INNER JOIN AdventureWorks2017.HumanResources.Employee AS e
ON (eph.BusinessEntityID = e.BusinessEntityID);


--- 6.

-- get only actual departments for every BusinessEntityID (means this person is currently working in this department)
SELECT * 
INTO ActualDepartments
FROM AdventureWorks2017.HumanResources.EmployeeDepartmentHistory AS edh
WHERE edh.EndDate IS NULL;

-- get actual departments with name
SELECT ad.BusinessEntityID, ad.DepartmentID, d.Name
INTO ActualDepartmentsWithName
FROM ActualDepartments AS ad
INNER JOIN AdventureWorks2017.HumanResources.Department AS d
ON (ad.DepartmentID = d.DepartmentID);


SELECT adn.BusinessEntityID, adn.DepartmentID, adn.Name, eph.Rate, 
-- get max rate in every department (partition by department name)
MAX(eph.Rate) OVER
(PARTITION BY adn.Name) AS MaxInDep,
-- this function returns the rank of each row within a result set partition
DENSE_RANK() OVER
(PARTITION BY adn.Name ORDER BY eph.Rate ASC) AS RateGroup
FROM ActualDepartmentsWithName AS adn
INNER JOIN
-- for every unique BusinessEntityID in ActualDepartmentsWithName join his history
AdventureWorks2017.HumanResources.EmployeePayHistory AS eph
ON (adn.BusinessEntityID = eph.BusinessEntityID);

-- delete temp tables
DROP TABLE ActualDepartmentsWithName;
DROP TABLE ActualDepartments;


--- 7. 
select * from AdventureWorks2017.HumanResources.Shift;

SELECT e.BusinessEntityID, e.JobTitle, s.Name, s.StartTime, s.EndTime
FROM AdventureWorks2017.HumanResources.Employee AS e
INNER JOIN AdventureWorks2017.HumanResources.EmployeeDepartmentHistory AS eph
ON (e.BusinessEntityID = eph.BusinessEntityID)
INNER JOIN AdventureWorks2017.HumanResources.Shift AS s
ON (eph.ShiftID = s.ShiftID)
WHERE s.Name = 'Evening';


