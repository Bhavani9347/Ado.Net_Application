create table student(studentid int primary key,studentname varchar(30));

 

drop table student;
--creating grade table
create table grade(stuid int foreign key references student(studentid),subjectname varchar(30),grade int);
go
drop table grade
go

 

--creating insert procedure for student table
create procedure usp_insertstudent(@studentid int,@studentname varchar(200))
as
begin
insert into student(studentid,studentname)values(@studentid,@studentname);
end
go
drop procedure usp_insertstudent;
go
--creating insert stored procedure for grade table
create procedure usp_insertgrade(@stuid int,@subjectname varchar(200),@grade int)
as
begin
insert into grade(stuid,subjectname,grade)values(@stuid,@subjectname,@grade);
end
go

 

drop procedure usp_insertgrade;
go
--procedure fr selecting student
create procedure usp_getstudent
as
begin
select * from student;
end
go

 

create procedure usp_getgrade
as
begin
select * from grade;
end
go

 

create procedure usp_updategrade(@stuid int,@grade int)
as
begin
update grade 
set grade=@grade
where stuid=@stuid;
end
