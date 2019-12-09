select * from Employees
ALTER TABLE FoodDrinks
Add FoodPrice float

ALTER TABLE Employees
Add Status int

ALTER TABLE Customers
Add Status int


DELETE FROM Tables 
DELETE FROM Customers 
DELETE FROM Employees 
DELETE FROM BookingTables
DELETE FROM OrderDetails
DELETE FROM Orders
delete from FoodDrinks


INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (1,'Pham Ngoc Thinh',0,'12/23/2000  12:00:00 AM','126777777','222 Nguyen Cong Tru, Thu Duc','123453181123','thinhthinh@gmail.com','a','1',1,1)
INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (2,'Tran Van Bao',0,'6/22/2000  12:00:00 AM','126888888','222 Lam Truong, Thu Duc','123454181123','tranvanbao@gmail.com','a','1',1,1)
INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (3,N'Nguyễn Đắc Thiên Ngân',1,'5/15/2000  12:00:00 AM',N'12677777','239 Nguyễn Kiệm, Gò Vấp','123454181123','nguyendacthienngan@gmail.com','a','1',1,1)
INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (4,N'Ung Bảo Tiên',1,'12/5/2000  12:00:00 AM','126000000',N'200 Quang Trung, Gò Vấp','123454181133','ungbaotien@gmail.com','tientien','190',0,0)
INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (5,N'Đinh Ngọc Uyên Phương',0,'1/1/2000  12:00:00 AM','12345678',N'Huỳnh Văn Bánh','12345678','phuong@gm.vn','Ngan','123',0,1)
INSERT INTO Employees (EmployeeID,Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (6,'Ngan',0,'1/1/2000  12:00:00 AM','456','abc','123','Ngan@gm.uit.edu.vn','Ngan','123',0,0)


SELECT * FROM Employees

INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (1,N'Gà sốt mật ong',N'Món an thom ngon',1,1,'https://anh.eva.vn/upload/3-2017/images/2017-09-27/canh-ga-sot-mat-ong-canh-ga-sot-mat-ong-7-1506478035-width650height492.jpg',25000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (2,N'Soda chanh đường',N'Giải khát cho những ngày nóng bức',1,0,'https://www.monngon.edu.vn/wp-content/uploads/2012/10/chanh-pha-soda.jpg',15000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (3,N'Cafe đá',N'Giải khát cho những ngày nóng bức',0,0,'http://coffee72.com/wp-content/uploads/2018/05/cafe-den-1-1000x668-1.jpg',12000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (4,N'Cơm chiên hải sản',N'Món ăn thơm ngon',1,1,'https://shipdoandemff.com/wp-content/uploads/2017/06/com-chien-hai-san-nha-hang-shipdoandemFF.png',28000)

SELECT * FROM FoodDrinks
SELECT * FROM Orders
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (1,'11/13/2019  11:42:08 PM',1,25000,10,1,3)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (2,'11/14/2019  12:07:00 AM',0,25000,10,1,3)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (3,'11/14/2019  12:14:17 AM',1,40000,10,4,3)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (4,'11/14/2019  7:59:52 AM',0,100000,10,4,3)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (5,'11/14/2019  9:04:30 AM',1,112000,10,9,1)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (6,'11/16/2019  10:29:05 PM',0,25000,10,1,1)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (7,'11/20/2019  3:14:08 PM',0,115000,10,1,1)
INSERT INTO Orders (OrderID,OrderDate,IsPaid,Total,CustomerID,TableID,EmployeeID) VALUES (8,'11/20/2019  3:19:48 PM',0,40000,10,3,1)


SET IDENTITY_INSERT Employees off
SET IDENTITY_INSERT Fooddrinks off
SET IDENTITY_INSERT Orders off
SET IDENTITY_INSERT OrderDetails on

SET IDENTITY_INSERT Customers off

SET IDENTITY_INSERT Tables off

INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (1,1,1,'None',25000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (2,1,1,'None',25000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (3,2,1,'None',15000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (4,1,2,'None',50000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (5,1,2,'None',50000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (6,3,1,'None',12000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (7,1,1,'None',25000)
INSERT INTO OrderDetails (OrderID, FoodDrinkID, Quantity, Note, Price) VALUES (8,1,2,'None',50000)


INSERT INTO Tables (TableID, TableName, Status)  VALUES (1,N'Bàn 1',2)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (2,N'Bàn 2',1)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (3,N'Bàn 3',2)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (4,N'Bàn 4',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (5,N'Bàn 5',1)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (6,N'Bàn 6',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (7,N'Bàn 7',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (8,N'Bàn 8',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (9,N'Bàn 9',0)					
					
SELECT * FROM Tables
INSERT INTO BookingTables (CustomerID,TableID,BookingDate,ExpiredTime) VALUES (1,1,'8/9/2019 9:20:00 AM','8/9/2019 10:20:00 AM')					
INSERT INTO BookingTables VALUES (2,4,'9/29/2019 3:20:00 PM','9/29/2019 4:20:00 PM')					
					
SELECT * FROM BookingTables
					
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (1,'Nguyen Thi Phuong Lan',1,'921009221','12345678910',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (2,'Nguyen Nam',0,'921009220','112345678910',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (3,'Nguyen Van Nhan',0,'921009222','212345678910',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (4,N'Dương Bảo San',1,'921309222','312345678910',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (5,N'Trần Thị Quỳnh Như',1,'921309232','312345678911',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (6,N'Trần Dương Vân Anh',1,'921309235','312345678912',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (7,N'Trần Dương Hà Lan',1,'921309238','312345678012',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (8,N'Hà Gia Bảo',0,'121309238','13345678012',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (9,N'Dương Cường',0,'126309238','13342678012',1)
INSERT INTO Customers (CustomerID,Name,IsFemale,PhoneNumber,CMND, Status) VALUES (10,N'Khách Vãng Lai',0,'126309238','13342678012',0)
	

SELECT *FROM Customers


SET IDENTITY_INSERT Tables off
SET IDENTITY_INSERT Customers Off	
