using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public class SalaryUpdateModel
    {
        public int SalaryId { get; set; }
        public string SalaryMonth { get; set; }
        public int EmployeeId { get; set; }
        public int EmpSalary { get; set; }
    }
}
