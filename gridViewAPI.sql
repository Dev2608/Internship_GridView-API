Declare @Id int
Set @Id = 1

While @Id <= 5000
Begin 
   Insert Into employee (emp_id,emp_name,emp_email) values (@Id ,('emp - ' + CAST(@Id as nvarchar(10))),
              ('employee' + CAST(@Id as nvarchar(10)) + '@gmail.com'))   
   Set @Id = @Id + 1
End

select * from employee where emp_id=213;

select * from employee;

select * from employee order by emp_id asc;