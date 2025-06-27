CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY, 
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY AUTO_INCREMENT, 
    FirstName VARCHAR(50), 
    LastName VARCHAR(50), 
    DepartmentID INT, 
    Salary DECIMAL(10,2), 
    JoinDate DATE, 
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

-- Exercise 1 : create a stored procedure

DELIMITER $$

CREATE PROCEDURE GetEmployeesByDepartment (
    IN p_DepartmentID INT
)
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM 
        Employees
    WHERE 
        DepartmentID = p_DepartmentID;
END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE sp_InsertEmployee (
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_DepartmentID INT,
    IN p_Salary DECIMAL(10,2),
    IN p_JoinDate DATE
)
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (p_FirstName, p_LastName, p_DepartmentID, p_Salary, p_JoinDate);
END$$

DELIMITER ;


-- Exercise 4 : Execute a stored procedure

CALL GetEmployeesByDepartment(2);
CALL sp_InsertEmployee('Alice', 'Walker', 3, 7200.00, '2022-05-01');



-- Exercise 5 : Return data from a stored procedure

DELIMITER $$

CREATE PROCEDURE GetEmployeeCountByDepartment (
    IN p_DepartmentID INT
)
BEGIN
    -- Count the number of employees in the given department
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = p_DepartmentID;
END$$

DELIMITER ;

CALL GetEmployeeCountByDepartment(1);


-- create a scalar function 

DELIMITER $$

CREATE FUNCTION fn_CalculateAnnualSalary(Salary DECIMAL(10, 2))
RETURNS DECIMAL(10, 2)
DETERMINISTIC
BEGIN
    -- Calculate the annual salary (Salary * 12)
    RETURN Salary * 12;
END$$

DELIMITER ;



-- Exercise 7: Return Data from a Scalar Function 

SELECT 
    EmployeeID, 
    FirstName, 
    LastName, 
    Salary, 
    fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM 
    Employees
WHERE 
    EmployeeID = 1;

