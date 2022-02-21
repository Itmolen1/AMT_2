using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeInformations>> All();
        Task<EmployeeInformations> Insert(EmployeeInformations employeeInformations);
        Task<EmployeeInformations> GetById(int Id);
        Task<EmployeeInformations> Update(EmployeeInformations employeeInformations);
        Task<EmployeeInformations> Delete(int Id);
    }
}
