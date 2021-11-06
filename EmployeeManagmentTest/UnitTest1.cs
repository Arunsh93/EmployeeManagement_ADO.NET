using EmployeeManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel salaryUpdate = new SalaryUpdateModel()
            {
                SalaryId = 12,
                SalaryMonth = "Jan",
                EmpSalary = 35000,
                EmployeeId = 12,
            };

            int EmpSalary = salary.UpdateEmployeeSalary(salaryUpdate);
            Assert.AreEqual(salaryUpdate.EmpSalary, EmpSalary);
        }
    }
}
