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
DBCC CHECKIDENT (Employees, RESEED, 0)

INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES ('Pham Ngoc Thinh',0,'12/23/2000  12:00:00 AM','126777777',N'222 Nguyễn Công Trứ, Thủ Đức','123453181123','thinhthinh@gmail.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES ('Tran Van Bao',0,'6/22/2000  12:00:00 AM','126888888',N'222 Lam Truong, Thu Duc','123454181123','tranvanbao@gmail.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (N'Nguyễn Đắc Thiên Ngân',1,'5/15/2000  12:00:00 AM',N'12677777',N'239 Nguyễn Kiệm, Gò Vấp','123454181123','nguyendacthienngan@gmail.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (N'Ung Bảo Tiên',1,'12/5/2000  12:00:00 AM','126000000',N'200 Quang Trung, Gò Vấp','123454181133','ungbaotien@gmail.com','tientien','190',0,0)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES (N'Đinh Ngọc Uyên Phương',0,'1/1/2000  12:00:00 AM','12345678',N'Huỳnh Văn Bánh','12345678','phuong@gm.vn','Ngan','123',0,1)

INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Trần Thanh Lâm',0,'1/1/2000','9756842325',N'111 Hàm nghi','185204515','185204515@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Huỳnh Thế Anh',0,'2/3/2000','3248679518',N'149 Nguyễn Thái Học','185203581','185203581@gm.com','a','1',0,1)

INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Trần Văn Bảo',0,'4/5/2000','1246359728',N'309 Nguyễn Huệ','185205427','185205427@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Chung Thái Dung',1,'24/8/2000','1257943657',N'168 Ung Văn Khiêm','185202840','185202840@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Đắc Thiên Ngân',1,'15/5/2000','9876352425',N'1031 Trần Phú','185200283','185200283@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Trần Hoàng Hiếu',0,'14/4/2000','9153975642',N'234 Lê Thành Phương','185200554','185200554@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Hoàng Đình Quang',1,'30/8/2000','986235741',N'567 Nguyễn Công Trứ','185204455','185204455@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Thành Đạt',1,'7/9/2000','953157624',N'231 Lê Lợi','185203986','185203986@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Thi Thanh Chương',1,'8/12/2000','9756842325',N'1118 Hàm nghi','185206247','185206247@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lương Duy Bảo',1,'1/8/2000','3248679518',N'1496 Nguyễn Thái Học','185200304','185200304@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Trần Phương Duy',1,'1/1/2000','9315682486',N'1201 Hồng Bàng','185205391','185205391@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Dương Minh Sang',1,'2/3/2000','1246359728',N'2343 Lê Thành Phương','185204843','185204843@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Thị Quỳnh Ngân',0,'2/11/2000','1257943657',N'5671 Nguyễn Công Trứ','185200387','185200387@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Tăng Khánh Chương',1,'4/5/2000','9876352425',N'2310 Lê Lợi','185200824','185200824@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Tô Hoài Quỳnh Vy',0,'24/8/2000','9153975642',N'1115 Hàm nghi','185204485','185204485@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lưu Đức Bảo',1,'15/5/2000','986235741',N'149 Nguyễn Thái Học','185203357','185203357@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Đức Chiến',1,'14/4/2000','953157624',N'179 Ngô Gia Tự','185204998','185204998@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Lê Bách',1,'30/8/2000','9756842325',N'309 Nguyễn Huệ','185206274','185206274@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Phạm Ngọc Thịnh',1,'7/9/2000','3248679518',N'1686 Ung Văn Khiêm','185201093','185201093@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Tân Hữu Toàn',1,'8/12/2000','9536175234',N'10315 Trần Phú','185200547','185200547@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Chí Thành',1,'1/8/2000','1246359728',N'3094 Nguyễn Huệ','185203420','185203420@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Đặng Ngọc Duy',1,'1/8/2000','1257943657',N'1683 Ung Văn Khiêm','185205794','185205794@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Đinh Quang Hoàng',1,'1/1/2000','9876352425',N'1031 Trần Phú','185205398','185205398@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Thành Đạt',1,'2/3/2000','9153975642',N'2340 Lê Thành Phương','185204847','185204847@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lê Tuấn Anh',1,'2/11/2000','986235741',N'5672 Nguyễn Công Trứ','185200387','185200387@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Đỗ Ngọc Thành',1,'4/5/2000','953157624',N'231 Lê Lợi','185201447','185201447@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Bùi Trọng Khánh Duy',1,'24/8/2000','9756842325',N'1119 Hàm nghi','185203181','185203181@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Đỗ Ngọc Cường',1,'15/5/2000','3248679518',N'1497 Nguyễn Thái Học','185200100','185200100@gm.com','a','1',0,0)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lê Trường Long Hưng',1,'14/4/2000','963548201',N'1231 Nguyễn khuyến','185204050','185204050@gm.com','a','1',1,0)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lê Đại Dương',1,'30/8/2000','1246359728',N'30 Nguyễn Huệ','185204859','185204859@gm.com','a','1',1,0)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Trương Minh Hiếu',1,'4/5/2000','1257943657',N'1680 Ung Văn Khiêm','185205287','185205287@gm.com','a','1',1,0)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Dư Chế Anh',1,'24/8/2000','9876352425',N'1031 Trần Phú','185204803','185204803@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Phạm Minh Việt',1,'15/5/2000','9153975642',N'2345 Lê Thành Phương','185203684','185203684@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Thẩm Minh Đức',1,'14/4/2000','986235741',N'567 Nguyễn Công Trứ','185203832','185203832@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Trùng Dương',1,'30/8/2000','953157624',N'23 Lê Lợi','185203606','185203606@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Thị Phương Lan',0,'7/9/2000','9756842325',N'1111 Hàm nghi','185206554','185206554@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Hoàng Nhi',0,'8/12/2000','3248679518',N'131 Nguyễn Thái Học','185202825','185202825@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Bùi Trần Tố Nữ',0,'1/8/2000','9032468516',N'268 Nguyễn Khuyến','185205781','185205781@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Phan Thị Mỹ Duyên',0,'1/8/2000','1246359728',N'3010 Nguyễn Huệ','185204517','185204517@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Bùi Công Nam',1,'1/1/2000','1257943657',N'169 Ung Văn Khiêm','185203580','185203580@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Noo Phước Thịnh',1,'2/3/2000','9876352425',N'1091 Trần Phú','185206542','185206542@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Đông Nhi',0,'2/11/2000','9153975642',N'237 Lê Thành Phương','185205423','185205423@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Hà My',0,'4/5/2000','986235741',N'56 Nguyễn Công Trứ','185202841','185202841@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Ngô Kiến Huy',1,'2/11/2000','953157624',N'2319 Lê Lợi','185200280','185200280@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Trấn Thành',1,'4/5/2000','9756842325',N'113 Hàm nghi','185200557','185200557@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyễn Anh Đức',1,'24/8/2000','3248679518',N'1491 Nguyễn Thái Học','185204450','185204450@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Xuân Mai',0,'15/5/2000','901254360',N'455 Võ Văn Ngân','185203984','185203984@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lê Giang',0,'14/4/2000','1246359728',N'309 Nguyễn Huệ','185206249','185206249@gm.com','a','1',0,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Lê Lộc',0,'30/8/2000','1257943657',N'109 Ung Văn Khiêm','185200302','185200302@gm.com','a','1',1,1)
INSERT INTO Employees (Name,IsFemale,DateOfBirth,PhoneNumber,Address,CMND,Email,Username,Password,IsAdmin, Status) VALUES(N'Nguyen Dac Thien Ngan',1,'1/1/2000','909090909',N'123 Phú Yên','9090909090','nguyen@gmail.com','nganndt_QL','$2a$10$NVHEBqzriKOZT4AcnLaHDuLiwL5D6y1uOGLqx2FW2dkvgwG6DqXGu',1,1)

SELECT * FROM Employees

INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (1,N'Gà sốt mật ong',N'Món an thom ngon',1,1,'https://anh.eva.vn/upload/3-2017/images/2017-09-27/canh-ga-sot-mat-ong-canh-ga-sot-mat-ong-7-1506478035-width650height492.jpg',25000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (2,N'Soda chanh đường',N'Giải khát cho những ngày nóng bức',1,0,'https://www.monngon.edu.vn/wp-content/uploads/2012/10/chanh-pha-soda.jpg',15000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (3,N'Cafe đá',N'Giải khát cho những ngày nóng bức',0,0,'http://coffee72.com/wp-content/uploads/2018/05/cafe-den-1-1000x668-1.jpg',12000)
INSERT INTO Fooddrinks (FoodDrinkID, FoodDrinkName, Description, IsAvailable, IsFood, ImageURL, FoodPrice) Values (4,N'Cơm chiên hải sản',N'Món ăn thơm ngon',1,1,'https://shipdoandemff.com/wp-content/uploads/2017/06/com-chien-hai-san-nha-hang-shipdoandemFF.png',28000)
Select * FROM Tables
SELECT * FROM FoodDrinks
SELECT * FROM Orders
SELECT * FROM Customers
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

set dateformat dmy
SELECT * FROM Tables
INSERT INTO Tables (TableID, TableName, Status)  VALUES (1,N'Bàn 1',0)					--0 :còn trống--1: đc đăt--2:có nguoi
INSERT INTO Tables (TableID, TableName, Status) VALUES (2,N'Bàn 2',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (3,N'Bàn 3',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (4,N'Bàn 4',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (5,N'Bàn 5',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (6,N'Bàn 6',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (7,N'Bàn 7',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (8,N'Bàn 8',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (9,N'Bàn 8',0)		

INSERT INTO Tables (TableID, TableName, Status) VALUES (10,N'Bàn 10',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (11,N'Bàn 11',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (12,N'Bàn 12',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (13,N'Bàn 13',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (14,N'Bàn 14',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (15,N'Bàn 15',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (16,N'Bàn 16',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (17,N'Bàn 17',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (18,N'Bàn 18',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (19,N'Bàn 19',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (20,N'Bàn 20',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (21,N'Bàn 21',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (22,N'Bàn 22',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (23,N'Bàn 23',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (24,N'Bàn 24',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (25,N'Bàn 25',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (26,N'Bàn 26',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (27,N'Bàn 27',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (28,N'Bàn 28',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (29,N'Bàn 29',0)					
INSERT INTO Tables (TableID, TableName, Status) VALUES (30,N'Bàn 30',0)					
					
SELECT * FROM Tables
INSERT INTO BookingTables (CustomerID,TableID,BookingDate,ExpiredTime) VALUES (1,1,'8/9/2019 9:20:00 AM','8/9/2019 10:20:00 AM')					
INSERT INTO BookingTables VALUES (2,4,'9/29/2019 3:20:00 PM','9/29/2019 4:20:00 PM')					
					
SELECT * FROM BookingTables

DBCC CHECKIDENT (Customers , RESEED, 0)					
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES ('Nguyen Thi Phuong Lan',1,'921009221','12345678910',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES ('Nguyen Nam',0,'921009220','112345678910',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES ('Nguyen Van Nhan',0,'921009222','212345678910',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Dương Bảo San',1,'921309222','312345678910',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Thị Quỳnh Như',1,'921309232','312345678911',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Dương Vân Anh',1,'921309235','312345678912',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Dương Hà Lan',1,'921309238','312345678012',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Hà Gia Bảo',0,'121309238','13345678012',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Dương Cường',0,'126309238','13342678012',1)
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Khách Vãng Lai',0,'126309238','13342678012',0)				

	
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Thanh Lâm',0,'9756842325','185204515',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Huỳnh Thế Anh',0,'3248679518','185203581',1)						
						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Văn Bảo',0,'1246359728','185205427',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Chung Thái Dung',1,'1257943657','185202840',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Đắc Thiên Ngân',1,'9876352425','185200283',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Trần Hoàng Hiếu',0,'9153975642','185200554',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Hoàng Đình Quang',1,'986235741','185204455',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Thành Đạt',1,'953157624','185203986',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Thi Thanh Chương',1,'9756842325','185206247',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lương Duy Bảo',1,'3248679518','185200304',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trần Phương Duy',1,'9315682486','185205391',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Dương Minh Sang',1,'1246359728','185204843',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Thị Quỳnh Ngân',0,'1257943657','185200387',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Tăng Khánh Chương',1,'9876352425','185200824',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Tô Hoài Quỳnh Vy',0,'9153975642','185204485',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lưu Đức Bảo',1,'986235741','185203357',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Đức Chiến',1,'953157624','185204998',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Lê Bách',1,'9756842325','185206274',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Phạm Ngọc Thịnh',1,'3248679518','185201093',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Tân Hữu Toàn',1,'9536175234','185200547',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Chí Thành',1,'1246359728','185203420',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Đặng Ngọc Duy',1,'1257943657','185205794',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Đinh Quang Hoàng',1,'9876352425','185205398',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Thành Đạt',1,'9153975642','185204847',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lê Tuấn Anh',1,'986235741','185200387',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Đỗ Ngọc Thành',1,'953157624','185201447',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Bùi Trọng Khánh Duy',1,'9756842325','185203181',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Đỗ Ngọc Cường',1,'3248679518','185200100',0)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lê Trường Long Hưng',1,'963548201','185204050',0)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lê Đại Dương',1,'1246359728','185204859',0)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trương Minh Hiếu',1,'1257943657','185205287',0)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Dư Chế Anh',1,'9876352425','185204803',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Phạm Minh Việt',1,'9153975642','185203684',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Thẩm Minh Đức',1,'986235741','185203832',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Trùng Dương',1,'953157624','185203606',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Thị Phương Lan',0,'9756842325','185206554',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Hoàng Nhi',0,'3248679518','185202825',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Bùi Trần Tố Nữ',0,'9032468516','185205781',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Phan Thị Mỹ Duyên',0,'1246359728','185204517',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Bùi Công Nam',1,'1257943657','185203580',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Noo Phước Thịnh',1,'9876352425','185206542',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Đông Nhi',0,'9153975642','185205423',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Hà My',0,'986235741','185202841',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Ngô Kiến Huy',1,'953157624','185200280',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Trấn Thành',1,'9756842325','185200557',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Nguyễn Anh Đức',1,'3248679518','185204450',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Xuân Mai',0,'901254360','185203984',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lê Giang',0,'1246359728','185206249',1)						
INSERT INTO Customers (Name,IsFemale,PhoneNumber,CMND, Status) VALUES (N'Lê Lộc',0,'1257943657','185200302',1)						

SELECT *FROM Customers


SET IDENTITY_INSERT Tables on
SET IDENTITY_INSERT Customers Off	
