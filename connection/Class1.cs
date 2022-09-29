using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connection
{
    public class connectToDb
    {
        SqlConnection con;

        public void connect()
        {
            con = new SqlConnection(
                "Data Source = DESKTOP-EFHH4AI\\SQLEXPRESS; " +
                "Initial Catalog = gridViewApi; " +
                "Integrated Security = true;");
        }

        //public DataSet selectEmployee(String p)
        //{
        //    con.Open();

        //    SqlDataAdapter a = new SqlDataAdapter(p, con);
        //    DataSet ds = new DataSet();
        //    a.Fill(ds);

        //    return (ds);

        //    con.Close();
        //}
        public DataSet selectEmployee(String p)
        {
            con.Open();

            SqlDataAdapter a = new SqlDataAdapter(p, con);
            DataSet ds = new DataSet();
            a.Fill(ds);

            return (ds);

            con.Close();
        }

        //public void insert(String Name, String email, DateTime joining,DateTime ending )
        //{
        //    con.Open();

        //    SqlDataAdapter adp = new SqlDataAdapter("" +
        //        "insert into joinendEmployee " +
        //        "(emp_name,emp_email,join_date,end_date) " +
        //        "values " +
        //        "('" + Name+"','"+email+"','"+joining+"','"+ending+"')", con);

        //    adp.SelectCommand.ExecuteNonQuery();

        //    con.Close();
        //}

        public void insert(String sp)
        {
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter(sp, con);

            adp.SelectCommand.ExecuteNonQuery();

            con.Close();
        }


    }
}
