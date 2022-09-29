create procedure spgetEmployee
as
begin

Declare @ID int
set @ID = 1

while @ID <=10
Begin
select emp_id,emp_name,emp_email from employee;
set @ID = @ID + 1
End

end

spgetEmployee;
