using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IVenderRepository
    {
        Task<List<VenderInformations>> All();
        Task<VenderInformations> Insert(VenderInformations venderInformations);
        Task<VenderInformations> GetById(int Id);
        Task<VenderInformations> Update(VenderInformations venderInformations);
        Task<VenderInformations> Delete(int Id);
        Task<bool> TrnExist(string trnNumber);
    }
}
