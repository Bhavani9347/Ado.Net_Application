create procedure retrievingjoins
as
begin
select movieinfo.title,sum(Ticketsales.amount) from movieinfo
inner join Ticketsales on movieinfo.movieid=Ticketsales.movieid
group by movieinfo.title;
end
go
