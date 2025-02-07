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

--INSERT INTO Units (Quantity) VALUES ('tim');
--INSERT INTO Units (Quantity) VALUES ('dag');
--INSERT INTO Units (Quantity) VALUES ('styck');

--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Alice', 'Andersson', 31);
--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Bob', 'Berg', 32);
--INSERT INTO Employees (FirstName, LastName, RoleId) VALUES ('Cecilia', 'Carlsson', 33);

--INSERT INTO Services (Name, Price, UnitId)
--VALUES ('Konsulttjänst', 150.00, 25);

--INSERT INTO Services (Name, Price, UnitId)
--VALUES ('Utveckling', 200.00, 26);

--INSERT INTO Services (Name, Price, UnitId)
--VALUES ('Support', 100.00, 27);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Alpha', '2025-01-01', '2025-06-01', 17, 28, 2);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Beta', '2025-02-01', '2025-07-01', 18, 29, 1);

--INSERT INTO Projects (Title, StartDate, EndDate, EmployeeId, CustomerId, StatusId)
--VALUES ('Project Gamma', '2025-03-01', '2025-08-01', 19, 30, 3);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (109, 12);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (109, 13);

--INSERT INTO ProjectServiceEntity (ProjectId, ServiceId)
--VALUES (111, 14);