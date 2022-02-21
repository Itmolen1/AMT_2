using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IDesignationRepository
    {
        Task<List<DesignationInformations>> All();
        Task<DesignationInformations> Insert(DesignationInformations designationInformations);
        Task<DesignationInformations> GetById(int Id);
        Task<DesignationInformations> Update(DesignationInformations designationInformations);
        Task<DesignationInformations> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
