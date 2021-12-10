using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoapptest.Models
{
    public class EmployeeDataAcessLayer
    {
        string connectionString = "Server=DESKTOP-QJHT6IE\\SQLEXPRESS;Database=EmployeeDB;User Id=sa;Password=password@123;";
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    lstEmployee.Add(employee);
                    con.Close();

                }
                return lstEmployee;
            }
        }
        public void AddEmployee(Employee employee)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Employee GerEmployeeById(int? Id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlquery = "Select * from Employee where EmployeeId= " + Id;
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.Id = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();

                }
                return employee;
            }
        }
        public void DeleteEmployee(int? Id)
        {
            Employee employee = new Employee();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteEmployee", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", Id);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }

        }
    }
}
