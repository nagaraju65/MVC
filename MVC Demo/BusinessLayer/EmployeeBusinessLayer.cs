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
        public IEnumerable<Employee> Employees
        {
            get
            {
                var emps = new List<Employee>();
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select Id, name, age, gender from tblEmployee", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        emps.Add(new Employee() { Id = int.Parse(rdr["Id"].ToString()), Age = int.Parse(rdr["age"].ToString()), Gender = rdr["gender"].ToString(), Name = rdr["name"].ToString() });
                    }

                    con.Close();
                }

                return emps;
            }
        }
    }
}
