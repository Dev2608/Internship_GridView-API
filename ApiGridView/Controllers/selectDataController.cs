using ApiGridView.Models;
using connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiGridView.Controllers
{
    public class selectDataController : ApiController
    {
        connectToDb ob1 = new connectToDb();
        DateTime endDate = new DateTime();        

        // for selecting all the employee from the table.
        //[Route("api/selectData/selectEmployee")]
        //[HttpGet]
        //public IHttpActionResult selectEmployee()
        //{
        //    try
        //    {
        //        ob1.connect();
        //        DataSet ds = ob1.selectEmployee("select * from employee1");

        //        var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
        //        {
        //            emp_id = dataRow.Field<String>("emp_id"),
        //            emp_name = dataRow.Field<String>("emp_name"),
        //            emp_email= dataRow.Field<String>("emp_email")
        //        });

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IHttpActionResult)ex;
        //    }
        //}

        //// for selecting top 10 employee from the table.
        //[Route("api/selectData/selectDefaultTenEmployee")]
        //[HttpGet]
        //public IHttpActionResult selectDefaultTenEmployee()
        //{
        //    try
        //    {
        //        ob1.connect();
        //        DataSet ds = ob1.selectEmployee("SELECT TOP 10 * from employee1");

        //        var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
        //        {
        //            emp_id = dataRow.Field<String>("emp_id"),
        //            emp_name = dataRow.Field<String>("emp_name"),
        //            emp_email = dataRow.Field<String>("emp_email")
        //        });

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IHttpActionResult)ex;
        //    }
        //}

        //// for selecting given number of employee from the table.
        //// FIRST PARAMETER
        //[Route("api/selectData/selectGivenNumberOfEmployee")]
        //[HttpGet]
        //public IHttpActionResult selectGivenNumberOfEmployee([FromBody] String numberOfEmployees)
        //{
        //    try
        //    {
        //        ob1.connect();
        //        DataSet ds = ob1.selectEmployee("SELECT TOP "+ numberOfEmployees + " * from employee1");

        //        var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
        //        {
        //            emp_id = dataRow.Field<String>("emp_id"),
        //            emp_name = dataRow.Field<String>("emp_name"),
        //            emp_email = dataRow.Field<String>("emp_email")
        //        });

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IHttpActionResult)ex;
        //    }
        //}

        //// select the data according to asec and desc with given attribute.
        //// parameter 4 & 5
        //[Route("api/selectData/selectEmployeeUsingOrderByWithAttribute")]
        //[HttpGet]
        //public IHttpActionResult selectEmployeeUsingOrderByWithAttribute([FromBody] String[] data)
        //{
        //    try
        //    {
        //        ob1.connect();
        //        DataSet ds = ob1.selectEmployee("SELECT * FROM employee1 ORDER BY "+ data[0] +" "+data[1]);

        //        var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
        //        {
        //            emp_id = dataRow.Field<String>("emp_id"),
        //            emp_name = dataRow.Field<String>("emp_name"),
        //            emp_email = dataRow.Field<String>("emp_email")
        //        });

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IHttpActionResult)ex;
        //    }
        //}

        //// get the employee data using pagination 
        //// in sql query, i m using OFFSET
        //// parameter 3
        //// Data[0] = emp_id (OrderBy Parameter) Data[1] = 20(Number of rows on single page) and Data[2] = 2(page number)
        //[Route("api/selectData/selectEmployeePagination")]
        //[HttpGet]
        //public IHttpActionResult selectEmployeePagination([FromBody] String[] Data)
        //{
        //    var temp1 = int.Parse(Data[1]);
        //    var temp2 = int.Parse(Data[2]);

        //    var temp = temp1 * temp2;
        //    temp = temp - temp1;
        //    var total = temp.ToString();

        //    try
        //    {
        //        ob1.connect();
        //        DataSet ds = ob1.selectEmployee("SELECT * from employee1 ORDER BY "+Data[0]+ " OFFSET "+ total + " ROWS FETCH NEXT "+ Data[1] +" ROWS ONLY");

        //        var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
        //        {
        //            emp_id = dataRow.Field<String>("emp_id"),
        //            emp_name = dataRow.Field<String>("emp_name"),
        //            emp_email = dataRow.Field<String>("emp_email")
        //        });

        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (IHttpActionResult)ex;
        //    }
        //}        


        // complete API with all 4 attributes
        // Data[0] = emp_id (OrderBy Parameter) Data[1] = 20(Number of rows on single page) and Data[2] = 2(page number) Data[3] = ASEC/DESC
        // Data[4] = nameToBeSearched in the table
        // in offset, the result is less then the offset number then no data will be displayed.
        [Route("api/selectData/selectEmployeeComplete")]
        [HttpGet]
        public IHttpActionResult selectEmployeeComplete([FromBody] String[] Data)
        {
            var temp1 = int.Parse(Data[1]);
            var temp2 = int.Parse(Data[2]);

            var temp = temp1 * temp2;
            temp = temp - temp1;
            var total = temp.ToString();
                
            try
            {
                ob1.connect();

                //DataSet ds = ob1.selectEmployee("SELECT * from employee1 " +
                //    "where emp_name LIKE '%"+ Data[4] +"%' " +
                //    "ORDER BY " + Data[0] +" "+ Data[3] + " " +
                //    "OFFSET " + total + " ROWS FETCH NEXT " + Data[1] + " ROWS ONLY");


                //DataSet ds = ob1.selectEmployee($"spGetEmployeeFromemployee2 {total}, {Data[1]}");

                //DataSet ds = ob1.selectEmployee($"spGetEmployeeFromemployee20 {Data[0]}, {Data[3]}, {total}, {Data[1]}");

                DataSet ds = ob1.selectEmployee($"spGetEmployeeByAllParam '{Data[4]}', '{Data[3]}', '{Data[0]}', {total}, {Data[1]}");

                // for converting the dataset object in list
                var list = ds.Tables[0].AsEnumerable().Select(dataRow => new employee1
                {
                    emp_id = dataRow.Field<int>("emp_id"),
                    emp_name = dataRow.Field<String>("emp_name"),
                    emp_email = dataRow.Field<String>("emp_email")
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }


        // insert API
        // this will take all the detail of employee
        // it will not take id bcoz it is identity
        // it will not take end date from the user, here end date will generating directly
        [Route("api/selectData/InsertEmployee")]
        [HttpPost]
        public IHttpActionResult InsertEmployee([FromBody] joinendEmployee data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ob1.connect();

                endDate = data.join_date.AddYears(1);

                //ob1.insert(data.emp_name, data.emp_email, data.join_date, endDate);

                ob1.insert($"spInsertEmployees '{data.emp_name}', '{data.emp_email}', '{data.join_date}', '{endDate}'");

                return Ok("Ending Date : "+endDate);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }

        // gives the list of employees whose end date is greater then the current date
        [Route("api/selectData/selectEmployeeWithEndDate")]
        [HttpGet]
        public IHttpActionResult selectEmployeeWithEndDate()
        {            
            try
            {
                ob1.connect();

                DataSet ds = ob1.selectEmployee("select * from joinendEmployee where end_date>GETDATE()");                    

                // for converting the dataset object in list
                var list = ds.Tables[0].AsEnumerable().Select(dataRow => new joinendEmployee
                {
                    emp_id = dataRow.Field<int>("emp_id"),
                    emp_name = dataRow.Field<String>("emp_name"),
                    emp_email = dataRow.Field<String>("emp_email"),
                    join_date = dataRow.Field<DateTime>("join_date"),
                    end_date = dataRow.Field<DateTime>("end_date")
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)ex;
            }
        }


    }
}
