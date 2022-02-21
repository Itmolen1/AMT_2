using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
     public interface IUnitRepository
    {
        Task<List<UnitInformations>> All();
        Task<UnitInformations> Insert(UnitInformations unitInformations );
        Task<UnitInformations> GetById(int Id);
        Task<UnitInformations> Update(UnitInformations unitInformations);
        Task<UnitInformations> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
