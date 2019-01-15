﻿USE StoreManagement
CREATE DATABASE StoreManagement

USE StoreManagement
GO
/****** Table PRODUCT ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE PRODUCT
(
	ID int NOT NULL,
	NAME nvarchar(30) NOT NULL,
	CATEGORY nvarchar(20) NOT NULL,
	PRODUCER nvarchar(10) NOT NULL,
	PURCHASE_PRICE int NOT NULL,
	PRICE int NOT NULL,
	INVENTORY int NOT NULL,
	CONSTRAINT PK_PRODUCT PRIMARY KEY (ID,NAME,PRICE)
)
CREATE TABLE BILL
(
	--ID của BILL
	ID_BILL int,
	--ID của product
	ID_PRODUCT int,
	--Tên Khách hàng
	NAME_CUSTOMER nvarchar(30) NOT NULL,
	--Tên SP
	NAME_PRODUCT nvarchar(30) NOT NULL,
		--Loai SP
	PRODUCER nvarchar(30) NOT NULL,
	-- Đơn giá
	PRICE int NOT NULL,
	--Ngày mua
	DATE_TIME date not null,
	--Số lượng
	AMOUNT int not null,
	-- So tien tra truoc
	ADVANCE int,
	--Hình thức thanh toán
	TYPE_PAY nvarchar(30) not null,
	--Tổng cộng
	TOTAL int not null,
	TRANGTHAI bit,
	CONSTRAINT PK_BILL PRIMARY KEY (ID_BILL)

)
 --SAMSUNG
  --Smartphone
INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (1, N'Samsung Galaxy A7',
 N'Smartphone',N'Samsung', 4000000, 4990000,10)
 INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (2, N'Samsung Galaxy A8 (2018)',
 N'Smartphone',N'Samsung', 6000000, 6990000,8)
  INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (3, N'Samsung Galaxy A9',
 N'Smartphone',N'Samsung', 10000000, 10990000,9)
  INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (4, N'Samsung Galaxy NOTE 9 512GB',
 N'Smartphone',N'Samsung', 27000000, 27990000,5)
  INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (5, N'Samsung Galaxy S9 PLUS',
 N'Smartphone',N'Samsung', 20000000, 20990000,6)
 --Tablet
  INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (6, N'Samsung Galaxy Tab S4 S-Pen',
 N'Tablet',N'Samsung', 17000000, 17990000,7)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (7, N'Samsung Galaxy Tab A',
 N'Tablet',N'Samsung', 9000000, 9490000,3)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (8, N'Samsung Galaxy J8',
 N'Smartphone',N'Samsung', 5500000, 6290000,6)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (9, N'Samsung Galaxy J7+',
 N'Smartphone',N'Samsung', 5000000, 5990000,4)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (10, N'Samsung Galaxy J6+',
 N'Smartphone',N'Samsung', 4000000, 4290000,1)

 --SAMSUNG


 --APPLE
 --Smartphone
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (11, N'Iphone Xs Max 512GB',
 N'Smartphone',N'Apple', 42000000, 43990000,10)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (12, N'Iphone Xs Max 256GB',
 N'Smartphone',N'Apple', 36000000, 37990000,9)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (13, N'Iphone Xs 256GB',
 N'Smartphone',N'Apple', 33000000, 34990000,7)
   INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (14, N'Iphone Xs Max 64GB',
 N'Smartphone',N'Apple', 32000000, 33990000,8)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (15, N'Iphone Xs 64GB',
 N'Smartphone',N'Apple', 29000000, 29990000,3)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (16, N'Iphone X 256GB',
 N'Smartphone',N'Apple', 29000000, 29990000,4)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (17, N'Iphone 8 Plus 256GB',
 N'Smartphone',N'Apple', 31000000, 29990000,6)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (18, N'Iphone X 64GB',
 N'Smartphone',N'Apple', 28000000, 24990000,3)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (19, N'Iphone 7 Plus 32GB',
 N'Smartphone',N'Apple', 15000000, 13990000,4)
    INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (20, N'Iphone 6s Plus 32GB',
 N'Smartphone',N'Apple', 12000000, 10990000,1)
 --Tablet
     INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (21, N'iPad Pro 11 inch Cellular 64GB',
 N'Tablet',N'Apple', 24000000, 25990000,15)
     INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (22, N'iPad Pro 11 inch 256GB ',
 N'Tablet',N'Apple', 24000000, 25990000,10)
     INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (23, N'iPad Pro 11 inch 64GB',
 N'Tablet',N'Apple', 24000000, 21990000,12)
     INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (24, N'iPad Pro 10.5 inch 64GB (2017)',
 N'Tablet',N'Apple', 18000000, 19990000,9)
     INSERT INTO PRODUCT (ID, NAME, CATEGORY, PRODUCER, PURCHASE_PRICE, PRICE,INVENTORY)  VALUES (25, N'iPad Pro 10.5 inch 128GB(2017)',
 N'Tablet',N'Apple', 20000000, 21990000,3)



 --APPLE

INSERT INTO BILL (ID_BILL,ID_PRODUCT,NAME_CUSTOMER,NAME_PRODUCT,PRODUCER,PRICE,AMOUNT,DATE_TIME,ADVANCE,TYPE_PAY,TOTAL,TRANGTHAI) VALUES (1,1,N'Nguyen Van A',N'Samsung Galaxy A7', N'Samsung',6990000, 1,CAST(N'2019-01-13' AS Date),0,N'In Full',6990000,1)
-- Hàm tạo lấy NSX bằng ngày
create procedure GETPRODUCERBYDAY(@day datetime)
as
SELECT BILL.PRODUCER, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND BILL.DATE_TIME = @day
GROUP BY PRODUCER 

exec GETPRODUCERBYDAY @day = '2019- 01 - 14'
-- Hàm tạo lấy NSX bằng tháng
create procedure GETPRODUCERBYMONTH(@month char(3),@year char (4))
as
SELECT BILL.PRODUCER, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND MONTH(BILL.DATE_TIME) = @month and YEAR(BILL.DATE_TIME) = @year
GROUP BY PRODUCER 

exec GETPRODUCERBYMONTH @month = '12',@year = '2018'
-- Hàm tạo lấy NSX bằng năm
create procedure GETPRODUCERBYYEAR(@year char (4))
as
SELECT BILL.PRODUCER, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND YEAR(BILL.DATE_TIME) = @year
GROUP BY PRODUCER 

exec GETPRODUCERBYYEAR @year = '2019'
-- Hàm tạo lấy NSX giữa 2 ngày
create procedure GETPRODUCERBY2DAYS(@day1 datetime,@day2 datetime)
as
SELECT BILL.PRODUCER, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND DATE_TIME >= @day1 AND DATE_TIME <= @day2
GROUP BY PRODUCER 

exec GETPRODUCERBY2DAYS @day1 = '2019 - 01 - 13',@day2 = '2019 - 01 - 14'
-- Hàm tạo lấy SẢN PHẦM TỪ NSX
create procedure GETPRODUCTBYPRODUCER(@produce char(20))
as
SELECT BILL.NAME_PRODUCT, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND BILL.PRODUCER = @produce
GROUP BY NAME_PRODUCT 

-- Hàm tạo lấy NSX
create procedure GETPRODUCER
as
SELECT BILL.PRODUCER, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 
GROUP BY PRODUCER 
exec GETPRODUCER 
-- Hàm tạo lấy SẢN PHẨM TỪ NSX THEO NGÀY
create procedure GETPRODUCTBYDAY(@day datetime,@produce char(10))
as
SELECT BILL.NAME_PRODUCT, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND BILL.DATE_TIME = @day AND bill.PRODUCER = @produce
GROUP BY NAME_PRODUCT 

exec GETPRODUCTBYDAY @day = '2019- 01 - 14',@produce = 'Samsung'

-- Hàm tạo lấy SẢN PHẨM TỪ NSX THEO THÁNG
create procedure GETPRODUCTBYMONTH(@month char(3),@year char (4),@produce char(10))
as
SELECT BILL.NAME_PRODUCT, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND MONTH(BILL.DATE_TIME) = @month and YEAR(BILL.DATE_TIME) = @year and BILL.PRODUCER = @produce
GROUP BY NAME_PRODUCT 

exec GETPRODUCTBYMONTH @month = '01',@year = '2019',@produce = 'Samsung'

-- Hàm tạo lấy SẢN PHẨM TỪ NSX THEO NĂM
create procedure GETPRODUCTBYYEAR(@year char (4),@produce char(10))
as
SELECT BILL.NAME_PRODUCT, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND YEAR(BILL.DATE_TIME) = @year AND PRODUCER = @produce
GROUP BY NAME_PRODUCT 

exec GETPRODUCTBYYEAR @year = '2019',@produce = 'Samsung'


-- Hàm tạo lấy SẢN PHẨM TỪ NSX GIỮA 2 NGÀY
create procedure GETPRODUCTBY2DAYS(@day1 datetime,@day2 datetime,@produce char(10))
as
SELECT BILL.NAME_PRODUCT, SUM(PRICE) as "Total"
FROM BILL
WHERE BILL.TRANGTHAI = 1 AND DATE_TIME >= @day1 AND DATE_TIME <= @day2 AND PRODUCER = @produce
GROUP BY NAME_PRODUCT 

exec GETPRODUCTBY2DAYS @day1 = '2019 - 01 - 13',@day2 = '2019 - 01 - 14',@produce = 'Samsung'
select *
from BILL
WHERE MONTH(DATE_TIME) = '1'
select datefromparts(2019, 1, 10)

create procedure GETREVENUEBYDAY(@day datetime)
AS
select ID_PRODUCT,SUM(AMOUNT) as Amount,PRODUCT.PURCHASE_PRICE
from BILL,PRODUCT
WHERE BILL.TRANGTHAI = 1 AND BILL.ID_PRODUCT = PRODUCT.ID AND BILL.DATE_TIME = @day
GROUP BY ID_PRODUCT,PRODUCT.PURCHASE_PRICE



exec GETREVENUEBYDAY @day = '2019 - 01 - 14'

create procedure GETREVENUEBY2DAY(@day1 datetime,@day2 datetime)
AS
select ID_PRODUCT,SUM(AMOUNT) as Amount,PRODUCT.PURCHASE_PRICE
from BILL,PRODUCT
WHERE BILL.TRANGTHAI = 1 AND BILL.ID_PRODUCT = PRODUCT.ID AND BILL.DATE_TIME >= @day1 and BILL.DATE_TIME <= @day2
GROUP BY ID_PRODUCT,PRODUCT.PURCHASE_PRICE



exec GETREVENUEBY2DAY @day1 = '2019 - 01 - 14',@day2 = '2019 - 01 - 15'