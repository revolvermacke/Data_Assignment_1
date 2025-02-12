--DELETE FROM ProjectServiceEntity;
--DELETE FROM Projects;
--DELETE FROM Employees;
--DELETE FROM "Services";
--DELETE FROM Units;
--DELETE FROM Roles;
--DELETE FROM Customers;


--INSERT INTO Roles (RoleName) VALUES ('Manager');
--INSERT INTO Roles (RoleName) VALUES ('Developer');
--INSERT INTO Roles (RoleName) VALUES ('Consultant');

--INSERT INTO Customers (Name) VALUES ('Acme Inc.');
--INSERT INTO Customers (Name) VALUES ('Globex Corp.');
--INSERT INTO Customers (Name) VALUES ('Initech');

--INSERT INTO Units (Unit) VALUES ('tim');
--INSERT INTO Units (Unit) VALUES ('dag');
--INSERT INTO Units (Unit) VALUES ('styck');

--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Alice', 'Andersson', 1);
--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Bob', 'Berg', 2);
--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Cecilia', 'Carlsson', 3);

--INSERT INTO Services (Name, Price, UnitId, Quantity)
--VALUES ('Konsulttjänst', 150.00, 1, 10);

--INSERT INTO Services (Name, Price, UnitId, Quantity)
--VALUES ('Utveckling', 200.00, 2, 5);

--INSERT INTO Services (Name, Price, UnitId, Quantity)
--VALUES ('Support', 100.00, 3, 10);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Alpha', '2025-01-01', '2025-06-01', 1, 1, 2);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Beta', '2025-02-01', '2025-07-01', 2, 2, 1);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Gamma', '2025-03-01', '2025-08-01', 3, 3, 3);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (100, 1);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (101, 2);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (102, 3);