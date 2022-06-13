--------------------------------------------------------- User
use [UAHP-Advertisment]
go

create proc InsertUser
@id nvarchar(450),
@name varchar(50),
@surname varchar(50),
@email varchar(50),
@phone varchar(15)
as
insert into [Users] (Id, [Name], Surname, Email, Phone)
values(@id, @name, @surname, @email, @phone)
go

create proc DeleteUserById
@id nvarchar(450)
as
delete from Users
where Id = @id
go

create proc GetAllUsers
as
select * from Users
go

create proc GetUserById
@id nvarchar(450)
as
select * from Users
where Id = @id
go

create proc UpdateUser
@id nvarchar(450),
@name varchar(50),
@surname varchar(50),
@email varchar(50),
@phone varchar(15)
as
update Users
set 
[Name] = @name,
Surname = @surname,
Email = @email,
Phone = @phone
where Id = @id
go

--------------------------------------------------------- Advertisment
create proc DeleteAdById
@id int
as
delete from Advertisments
where Id = @id
go

create proc GetAllAdvertisments
as
select * from Advertisments
go

create proc GetAdvertismentById
@id int
as
select * from Advertisments
where Id = @id
go

create proc InsertAdvertisment
@userId nvarchar(450),
@price float,
@region varchar(50),
@city varchar(50),
@street varchar(50),
@houseNumber varchar(50),
@houseType varchar(50),
@areaOfHouse int,
@floorAmount int,
@roomNumber int,
@houseYear int,
@pool bit,
@balkon bit,
@rentOportunity bit,
@description varchar(max)
as
insert into Advertisments(UserId, Price, Region, City, Street, HouseNumber, HouseType, AreaOfHouse, FloorAmount, RoomNumber, HouseYear, [Pool], Balkon, RentOportunity, [Description])
OUTPUT INSERTED.Id
values       (@userId,  @price, @region, @city, @street, @houseNumber, @houseType, @areaOfHouse, @floorAmount, @roomNumber, @houseYear, @pool, @balkon, @rentOportunity, @description)
go

use [UAHP-Advertisment]
go

use [UAHP-Advertisment]
go

create proc InsertAndGetInsertedAdvertisment
@userId nvarchar(450),
@price float,
@region varchar(50),
@city varchar(50),
@street varchar(50),
@houseNumber varchar(50),
@houseType varchar(50),
@areaOfHouse int,
@floorAmount int,
@roomNumber int,
@houseYear int,
@pool bit,
@balkon bit,
@rentOportunity bit,
@description varchar(max)
as
insert into Advertisments(UserId, Price, Region, City, Street, HouseNumber, HouseType, AreaOfHouse, FloorAmount, RoomNumber, HouseYear, [Pool], Balkon, RentOportunity, [Description])
output inserted.Id, inserted.UserId, inserted.Price, inserted.Region, inserted.City, inserted.Street, inserted.HouseNumber, inserted.HouseType,
inserted.AreaOfHouse, inserted.FloorAmount, inserted.RoomNumber, inserted.HouseYear, inserted.[Pool], inserted.Balkon, inserted.RentOportunity, inserted.[Description]
values       (@userId,  @price, @region, @city, @street, @houseNumber, @houseType, @areaOfHouse, @floorAmount, @roomNumber, @houseYear, @pool, @balkon, @rentOportunity, @description)
go

create proc UpdateAdvertisment
@id int,
@userId nvarchar(450),
@price float,
@region varchar(50),
@city varchar(50),
@street varchar(50),
@houseNumber varchar(50),
@houseType varchar(50),
@areaOfHouse int,
@floorAmount int,
@roomNumber int,
@houseYear int,
@pool bit,
@balkon bit,
@rentOportunity bit,
@description varchar(max)
as
update Advertisments
set
Price = @price,
Region = @region,
City = @city,
Street = @street,
HouseNumber = @houseNumber,
HouseType = @houseType,
AreaOfHouse = @areaOfHouse,
FloorAmount = @floorAmount,
RoomNumber = @roomNumber,
HouseYear = @houseYear,
[Pool] = @pool,
Balkon = @balkon,
RentOportunity = @rentOportunity,
[Description] = @description
where Id = @id
go

--------------------------------------------------------- Images
create proc InsertImage
@advertismentId int,
@imageFile varbinary(max)
as
insert into Images (AdvertismentId, ImageFile)
values(@advertismentId, @imageFile)
go

create proc GetImagesByAdId
@advertismentId int
as
select * from Images
where AdvertismentId = @advertismentId
go

create proc DeleteImageById
@id int
as
delete from Images
where Id = @id
go

--------------------------------------------------------- Tags
create proc InsertTag
@tagName varchar(max)
as
insert into Tags (TagName)
values(@tagName)
go

create proc DeleteTagByName
@tagName varchar(max)
as
delete from Tags
where TagName = @tagName
go

create proc GetAllTags
as
select * from Tags
go
--------------------------------------------------------- AdTag
create proc InsertIntoAdTag
@advertismentId int,
@tagsTagName varchar(max)
as
insert into AdTag(AdvertismentsId, TagsTagName)
values (@advertismentId, @tagsTagName)
go

create proc GetTagsByAdId
@advertismentId int
as
select TagsTagName TagName
from AdTag
--------------------------------------------------------- Drop procedures
--drop proc DeleteAdById
--drop proc DeleteUserById
--drop proc GetAllAdvertisments
--drop proc GetAdvertismentById
--drop proc GetAllUsers
--drop proc GetImagesByAdId
--drop proc GetUserById
--drop proc InsertAdvertisment
--drop proc InsertImage
--drop proc InsertIntoAdTag
--drop proc InsertTag
--drop proc InsertUser
--drop proc UpdateAdvertisment
--drop proc UpdateUser

----------------------------------------------------------- Seeding
--exec InsertAdvertisment 'string', 31, 'Region', 'City', 'Street', 'HouseNumber', 'HouseType', 67, 7, 7, 7, 1, 1, 1, 'asd'