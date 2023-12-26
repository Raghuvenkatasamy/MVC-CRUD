use Batch7

CREATE TABLE MobileDetailsAPI
(
    MobileId bigint NOT NULL primary key identity(1,1),
	Name varchar(50) NOT NULL,
	ManufactureName nvarchar(50) NOT NULL,
	DateofMaufacture date NOT NULL,
	YearofMaufacture bigint NOT NULL,
	Quantity int not null
) 

drop table MobileDetailsAPI
truncate table MobileDetailsAPI
select*from  MobileDetailsAPI

--Insert
create procedure InsertMobileDetail
@Name varchar(50),@ManufactureName nvarchar(50),@DateofMaufacture date,@YearofMaufacture bigint,@Quantity int
as
begin
insert into MobileDetailsAPI values(@Name,@ManufactureName,@DateofMaufacture,@YearofMaufacture,@Quantity)
end

drop procedure InsertMobileDetails

exec InsertMobileDetail 'sss','qwer','11/11/1111',2003,2

--Update

create procedure UpdateMobileDetail
@MobileId bigint,@Name varchar(50),@ManufactureName nvarchar(50),@DateofMaufacture date,@YearofMaufacture bigint,@Quantity int
as
begin
update MobileDetailsAPI set Name=@Name,ManufactureName=@ManufactureName,DateofMaufacture=@DateofMaufacture,YearofMaufacture=@YearofMaufacture,Quantity=@Quantity  where MobileId=@MobileId
end

drop procedure UpdateMobileDetails
exec UpdateMobileDetail 2,'www','qwer','11/11/1111',2003,2


--Delete
create procedure DeleteMobileDetail
@MobileId bigint 
as
begin
delete from MobileDetailsAPI where MobileId=@MobileId
end

exec DeleteMobileDetail 1

-- select

create procedure ReadMobileDetail
as
begin
select * from MobileDetailsAPI
end

--Selectbynumber

create procedure ReadbynumMobileDetail
@MobileId bigint
as
begin
select * from MobileDetailsAPI where MobileId=@MobileId
end

exec ReadbynumMobileDetail 2

exec InsertMobileDetail
exec UpdateMobileDetail
exec DeleteMobileDetail
exec ReadMobileDetail

select * from MobileDetailsAPI
