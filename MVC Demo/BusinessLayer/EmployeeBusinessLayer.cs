using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<BO_Employee> Employees
        {
            get
            {
                var emps = new List<BO_Employee>();
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select Id, name, age, gender from tblEmployee", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        emps.Add(new BO_Employee()
                        {
                            Id = int.Parse(rdr["Id"].ToString()),
                            Age = int.Parse(rdr["age"].ToString()),
                            Gender = rdr["gender"].ToString(),
                            Name = rdr["name"].ToString()
                        });
                    }

                    con.Close();
                }

                return emps;
            }
        }

        public int InsertEmployee(BO_Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsert_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter P_Name = new SqlParameter("@Name", employee.Name);
                cmd.Parameters.Add(P_Name);
                SqlParameter P_Age = new SqlParameter("@Age", employee.Age);
                cmd.Parameters.Add(P_Age);
                SqlParameter P_Gender = new SqlParameter("@Gender", employee.Gender);
                cmd.Parameters.Add(P_Gender);
                con.Open();
                return cmd.ExecuteNonQuery();
             }

        }
    }
}
