create procedure spGetEmployeeFromemployee2

@total as int,
@pgrow as int 

as
begin

SELECT * from employee1 where emp_name LIKE '%%' ORDER BY emp_id DESC OFFSET @total ROWS FETCH NEXT @pgrow ROWS ONLY

end

spGetEmployeeFromemployee2 20,20
