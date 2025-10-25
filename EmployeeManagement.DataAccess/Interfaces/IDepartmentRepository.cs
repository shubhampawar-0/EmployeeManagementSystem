using EmployeeManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int id);

        bool AddDepartment(Department department);

        bool UpdateDepartment(Department department);

        bool deleteDepartment(int id);




    }
}
