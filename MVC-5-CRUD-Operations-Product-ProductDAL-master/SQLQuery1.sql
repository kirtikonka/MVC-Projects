create database Proj5MVCKirti

create table product(id int primary key identity, pname varchar(100), pcat varchar(100), price decimal(9,2));

select * from product;

create proc sp_insert
@pname varchar(100),
@pcat varchar(100),
@price decimal(9,2)
as
begin
insert into product(pname, pcat, price) values(@pname, @pcat,@price);
end

create proc sp_show
as
begin
select * from product;
end

EXEC SP_INSERT 'Mobile','Electronics',999

create proc sp_del
@id int
as
begin
delete from product where id = @id;
end

create proc sp_edit
@id int
as
begin
select * from product where id =@id;
end

create proc sp_update
@id int,
@pname varchar(100),
@pcat varchar(100),
@price decimal(9,2)
as
begin
update product set pname=@pname, pcat=@pcat,price=@price where id =@id;
end