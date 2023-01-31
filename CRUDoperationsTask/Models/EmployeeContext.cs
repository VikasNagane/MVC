using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CRUDoperationsTask.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Employeedb;Integrated Security=true");
        public List<EmployeeModel> getAllEmployees()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("usp_getEmployees",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();

                emp.CandidateID = Convert.ToInt32(dr["CandidateID"]);
                emp.EmpID = Convert.ToInt32(dr["EmpID"]);
                emp.EmpName = Convert.ToString(dr["EmpName"]);
                emp.Email = Convert.ToString(dr["Email"]);
                emp.ContactNo = Convert.ToInt32(dr["ContactNo"]);


                listEmp.Add(emp);
            }


            return listEmp;
        }

        public int SaveEmployee(EmployeeModel emp)
        {
            SqlCommand cmd = new SqlCommand("usp_SaveEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
            cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@ContactNo", emp.ContactNo);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public EmployeeModel GetEmployeeByID(int ? id)
        {
            EmployeeModel emp = new EmployeeModel();
            SqlCommand cmd = new SqlCommand("usp_GetEmployeeByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                
               // emp.CandidateID = Convert.ToInt32(dr["CandidateID"]);
                emp.EmpID = Convert.ToInt32(dr["EmpID"]);
                emp.EmpName = Convert.ToString(dr["EmpName"]);
                emp.Email = Convert.ToString(dr["Email"]);
                emp.ContactNo = Convert.ToInt32(dr["ContactNo"]);

                
            }
            return emp;
        }


        public int UpdateEmployee(EmployeeModel emp)
        {
            SqlCommand cmd = new SqlCommand("usp_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpID", emp.EmpID);
            cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@ContactNo", emp.ContactNo);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }



        public int DeleteEmployee(int ? id)
        {
            SqlCommand cmd = new SqlCommand("usp_DeleteEmployeebyID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpID",id);
         
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
