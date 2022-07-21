using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CRUDusingADO.Models;

namespace CRUDusingADO
{
    public class Employee2Dal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Employee2Dal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Employee2> GetAllEmployee2()
        {
            List<Employee2> elist = new List<Employee2>();
            string qry = "select * from Employee2";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee2 E = new Employee2();
                    E.EmpId = Convert.ToInt32(dr["EmpId"]);
                    E.EmpName = dr["EmpName"].ToString();
                    E.EmpSalary = Convert.ToInt32(dr["EmpSalary"]);

                    elist.Add(E);
                }
            }
            con.Close();
            return elist;
        }
        public Employee2 GetEmployee2ById(int id)
        {
            Employee2 E= new Employee2();
            string qry = "select * from Employee2 where EmpId=@EmpId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EmpId", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    E.EmpId = Convert.ToInt32(dr["EmpId"]);
                    E.EmpName = dr["EmpName"].ToString();
                    E.EmpSalary = Convert.ToInt32(dr["EmpSalary"]);
                }
            }
            con.Close();
            return E;
        }

        public int AddEmployee(Employee2 emplo)
        {
            string qry = "insert into Employee2 values(@EmpName , @EmpSalary)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@EmpName", emplo.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", emplo.EmpSalary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee2 emplo)
        {
            string qry = "update Employee2 set EmpName=@EmpName EmpSalary=@EmpSalary where EmpId=@EmpId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EmpId", emplo.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", emplo.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", emplo.EmpSalary);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Employee2 where EmpId=@EmpId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EmpId", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
