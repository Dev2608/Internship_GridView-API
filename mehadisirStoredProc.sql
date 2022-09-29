declare @param1 nvarchar(max)='asc';
declare @param2 nvarchar(max)='emp_name';
declare @total int=20;
declare @pgrow int=20;

SELECT [emp_id]
      ,[emp_name]
      ,[emp_email]
  FROM [dbo].[employee1]
  order by
  case when @param2='emp_name' and @param1='asc' then emp_name end asc,
  case when @param2='emp_name' and @param1='desc' then emp_name end desc,
  case when @param2='emp_email' and @param1='asc' then emp_name end asc,
  case when @param2='emp_email' and @param1='desc' then emp_name end desc 

  OFFSET @total ROWS FETCH NEXT @pgrow ROWS ONLY;


