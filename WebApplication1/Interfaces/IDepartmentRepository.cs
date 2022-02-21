using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentInformations>> All();
        Task<DepartmentInformations> Insert(DepartmentInformations departmentInformations);
        Task<DepartmentInformations> GetById(int Id);
        Task<DepartmentInformations> Update(DepartmentInformations departmentInformations);
        Task<DepartmentInformations> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
