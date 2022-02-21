using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IBloodGroupRepository
    {
        Task<List<BloodGroupInformations>> All();
        Task<BloodGroupInformations> Insert(BloodGroupInformations bloodGroupInformations);
        Task<BloodGroupInformations> GetById(int Id);
        Task<BloodGroupInformations> Update(BloodGroupInformations bloodGroupInformations);
        Task<BloodGroupInformations> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
