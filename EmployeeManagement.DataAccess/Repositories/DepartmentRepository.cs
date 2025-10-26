using EmployeeManagement.DataAccess.Interfaces;
using EmployeeManagement.DataAccess.SQL;
using EmployeeManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.
    Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConnectionHelper _dbConnectionHelper;

        public DepartmentRepository(DbConnectionHelper dbConnectionHelper)
        {
            _dbConnectionHelper = dbConnectionHelper;     
        }



        public IEnumerable<Department> GetDepartments()
        {
            try
            {

                var departmentlist = new List<Department>();

                using (


                    var con = _dbConnectionHelper.CreateConnection())
                {
                    con.Open();

                    using (var cmd = new SqlCommand("SELECT DepartmentId, DepartmentName FROM Departments", (SqlConnection)con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                departmentlist.Add(new Department
                                {
                                    DepartmentId = (int)reader["DepartmentId"],
                                    DepartmentName = reader["DepartmentName"].ToString()
                                });
                            }
                        }
                    }
                }

                return departmentlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Department GetDepartmentById(int id)
        {

            try
            {
                Department dept = null;

                using (var conn = _dbConnectionHelper.CreateConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT DepartmentId, DepartmentName FROM Departments WHERE DepartmentId=@Id", (SqlConnection)conn))
                    {
                        // Correct way to add parameter
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Reads the first row if exists
                            {
                                dept = new Department
                                {
                                    DepartmentId = (int)reader["DepartmentId"],
                                    DepartmentName = reader["DepartmentName"].ToString()
                                };
                            }
                        }
                    }
                }
                return dept; // Will be null if not found
            }
            catch (Exception ex )
            {

                throw ex;
            }

            
        }

        public bool AddDepartment(Department dept)
        {
            using (var conn = _dbConnectionHelper.CreateConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand("INSERT INTO Departments (DepartmentName) VALUES (@Name)",(SqlConnection)conn ))
                {
                    cmd.Parameters.AddWithValue("@Name", dept.DepartmentName);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateDepartment(Department department)
        {
            using (var conn = _dbConnectionHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("UPDATE Departments SET DepartmentName=@Name WHERE DepartmentId=@Id", (SqlConnection)conn))
                {
                    cmd.Parameters.AddWithValue("@Name", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@Id", department.DepartmentId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool deleteDepartment(int id)
        {
            using (var conn = _dbConnectionHelper.CreateConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Departments WHERE DepartmentId=@Id", (SqlConnection)conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
