alter procedure spInsertEmployees

@param1 nvarchar(max),
@param2 nvarchar(max),
@param3 nvarchar(max),
@param4 nvarchar(max)

as
begin

insert into joinendEmployee (emp_name,emp_email,join_date,end_date) values (@param1,@param2,@param3,@param4)

end


spInsertEmployees 'kandy','kandy@gmail.com','2018-10-10','2019-10-10'

select * from joinendEmployee;

