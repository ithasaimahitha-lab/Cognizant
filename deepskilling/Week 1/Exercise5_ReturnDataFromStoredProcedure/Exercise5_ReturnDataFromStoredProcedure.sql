USE CognizantAdvancedSQL;
GO

--------------------------------------------------
-- Create Stored Procedure
--------------------------------------------------

DROP PROCEDURE IF EXISTS sp_GetEmployeeCountByDepartment;
GO

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        @DepartmentID AS DepartmentID,
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

--------------------------------------------------
-- Execute Procedure
--------------------------------------------------

EXEC sp_GetEmployeeCountByDepartment 3;
GO