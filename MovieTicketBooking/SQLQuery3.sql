create table movieinfo(movieid int not null Primary key,title varchar(20) not null,releasedate datetime not null,genre varchar not null);
go

drop table movieinfo;
go

create table Ticketsales(salesid int Primary key,movieid int Foreign key references movieinfo(movieid),screeenno int not null,showtime varchar(20),quantity int,amount float,price float);
go

drop table Ticketsales;
go
--sp for inserting
Create Procedure insertmovieinfo(@movieid int,@title varchar(20),@releasedate datetime,@genre varchar)
AS
begin
Insert into movieinfo(movieid,title,releasedate,genre)Values(@movieid,@title,@releasedate,@genre);
End
go

drop Procedure insertmovieinfo;
go

--sp for inserting ticketssales
Create Procedure insertticketsales(@salesid int,@movieid int,@screeenno int,@showtime varchar(20),@quantity int,@amount float,@price float)
AS
begin
Insert into Ticketsales(salesid,movieid,screeenno,showtime,quantity,amount,price)Values(@salesid,@movieid,@screeenno,@showtime,@quantity,@amount,@price);
End
go

drop procedure insertticketsales;
go

--sp for retrieve movieinfo
Create procedure gettickectsinfo
AS
begin
Select * from movieinfo;
end
go

--sp for retrieving the tickecsale
Create procedure getticketsales
as
begin
select *from Ticketsales;
end
go

---updating the movieinfo table
create procedure updatemovieinfo
as
begin
update movieinfo
set movieid=300
where movieid<40 
end
go

--Sp for joins
create procedure retrievingjoins
as
begin
select movieinfo.title,sum(Ticketsales.amount) from movieinfo
inner join Ticketsales on movieinfo.movieid=Ticketsales.movieid
group by movieinfo.title;
end
go

