alter procedure spGetEmployeeByAllParam

@param3 nvarchar(max),
@param1 nvarchar(max),
@param2 nvarchar(max),
@total int,
@pgrow int

as
begin

SELECT [emp_id]
      ,[emp_name]
      ,[emp_email]
  FROM [dbo].[employee1]
  where emp_name LIKE '%'+@param3+'%'
  order by
  case when @param2='emp_name' and @param1='asc' then emp_name end asc,
  case when @param2='emp_name' and @param1='desc' then emp_name end desc,
  case when @param2='emp_email' and @param1='asc' then emp_name end asc,
  case when @param2='emp_email' and @param1='desc' then emp_name end desc 

  OFFSET @total ROWS FETCH NEXT @pgrow ROWS ONLY;

end


spGetEmployeeByAllParam '','desc','emp_name',20,20

