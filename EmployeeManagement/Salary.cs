using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Services;Integrated Security=True");
        }

        public int UpdateEmployeeSalary(SalaryUpdateModel model)
        {
            SqlConnection salaryConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (salaryConnection)
                {
                    SalaryDetailModel salaryDetail = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("SpUpdateEmployeeSalary", salaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", model.SalaryId);
                    command.Parameters.AddWithValue("@Month", model.SalaryMonth);
                    command.Parameters.AddWithValue("@Salary", model.EmpSalary);
                    command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);

                    salaryConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            salaryDetail.Id = (int)reader["Id"];
                            salaryDetail.EmpName = reader["EmpName"].ToString();
                            salaryDetail.EmpSalary = (int)reader["EmpSalary"];
                            salaryDetail.SalaryMonth = reader["SalaryMonth"].ToString();
                            salaryDetail.SalaryId = (int)reader["SalaryId"];

                            Console.WriteLine("{0}, {1}, {2}", salaryDetail.EmpName, salaryDetail.EmpSalary, salaryDetail.SalaryMonth);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                salaryConnection.Close();
            }
            return salary;
        }
    }
}
