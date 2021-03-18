using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Lab4_WebServiceDemo.Models;
using System.Data;
using System.Data.SqlClient;

namespace API_Lab4_WebServiceDemo.Models
{
    public class db
    {
        //"provider=SQLNCLI11;" +
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G2GES0F;Initial Catalog=DemoCRUD;Integrated Security=True");
        //Lấy dữ liệu
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        //nhập và cập nhật
        public string Empdml(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }


    }
}
