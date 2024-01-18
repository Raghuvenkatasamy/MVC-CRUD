
select*from Registration
truncate table Registration

create procedure InsertRegistration
(@username nvarchar(50),@password nvarchar(50),@conformpassword nvarchar(50))
as
begin
INSERT into Registration values(@username,@password,@conformpassword)

end
drop procedure InsertRegistration
exec InsertRegistration 'gopal','gopu123','gopu123'

create procedure Checkpassword
(@username nvarchar(50),@password nvarchar(50))
as
begin
select*from Registration where UserName=@username and Password=@password 
end

drop procedure Checkpassword

exec Checkpassword 'virak','123'

create procedure Getall
as
begin
select*from Registration
end

drop procedure Getall

exec Getall

create procedure CheckRegistration
(@username nvarchar(50),@password nvarchar(50),@conformpassword nvarchar(50))
as
begin
select*from Registration where UserName=@username or Password=@password or ConformPassword=@conformpassword
end

exec CheckRegistration 'go','ram','oggi'


create procedure Getbyid
(@RegisterId bigint)
as
begin
select*from Registration where RegistrationId=@RegisterId
end

drop procedure Getbyid

exec Getbyid 9

create procedure DeleteRecord
(@RegisterId bigint)
as
begin
delete from Registration where RegistrationId=@RegisterId
end

drop procedure DeleteRecord

exec DeleteRecord 12

create procedure UpdateRecord
(@RegisterId bigint,@username nvarchar(50),@password nvarchar(50),@conformpassword nvarchar(50))
as
begin
update Registration set UserName=@username,Password=@password,ConformPassword=@conformpassword where RegistrationId=@RegisterId
end

drop procedure UpdateRecord
exec UpdateRecord 1,'ram','ram','ram'

select*from Registration