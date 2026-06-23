USE CognizantAdvancedSQL;
GO

--------------------------------------------------
-- CLEANUP
--------------------------------------------------

DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
DROP PROCEDURE IF EXISTS sp_InsertEmployee;
GO

DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
GO

--------------------------------------------------
-- CREATE TABLES
--------------------------------------------------

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

--------------------------------------------------
-- INSERT SAMPLE DATA
--------------------------------------------------

INSERT INTO Departments
VALUES
(1,'HR'),
(2,'Finance'),
(3,'IT'),
(4,'Marketing');
GO

INSERT INTO Employees
VALUES
(1,'John','Doe',1,5000.00,'2020-01-15'),
(2,'Jane','Smith',2,6000.00,'2019-03-22'),
(3,'Michael','Johnson',3,7000.00,'2018-07-30'),
(4,'Emily','Davis',4,5500.00,'2021-11-05');
GO

--------------------------------------------------
-- STORED PROCEDURE 1
--------------------------------------------------

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

--------------------------------------------------
-- STORED PROCEDURE 2
--------------------------------------------------

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees
    (
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    )
    VALUES
    (
        (SELECT MAX(EmployeeID) + 1 FROM Employees),
        @FirstName,
        @LastName,
        @DepartmentID,
        @Salary,
        @JoinDate
    );
END;
GO

--------------------------------------------------
-- TEST INSERT PROCEDURE
--------------------------------------------------

EXEC sp_InsertEmployee
    'Chris',
    'Brown',
    3,
    8000.00,
    '2024-01-10';
GO

--------------------------------------------------
-- TEST RETRIEVAL PROCEDURE
--------------------------------------------------

EXEC sp_GetEmployeesByDepartment 3;
GO

--------------------------------------------------
-- VERIFY DATA
--------------------------------------------------

SELECT * FROM Employees;
GO