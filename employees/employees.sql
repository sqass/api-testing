USE employee;


CREATE TABLE EmployeeDetails (
    EmployeeID INT ,
    FirstName VARCHAR(100),
	LastName VARCHAR(100),
    Age INT,
    State VARCHAR(2)
);



-- INSERT INTO EmployeeDetails (EmployeeID, FirstName, LastName, Age, CITY)
-- VALUES (1, 'John', 'Doe', 30, 1);

delete  from EmployeeDetails where EmployeeID=2;

SELECT * FROM EmployeeDetails

-- DROP TABLE EmployeeDetails