using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IControlAccountRepository
    {
        Task<List<ControlAccountInformations>> All();
        Task<ControlAccountInformations> Insert(ControlAccountInformations controlAccountInformations);
        Task<ControlAccountInformations> GetById(int Id);
        Task<ControlAccountInformations> Update(ControlAccountInformations controlAccountInformations);
        Task<ControlAccountInformations> Delete(int Id);
        Task<int> GetAccountCode(int Id);
        Task<bool> Exist(string Name);
    }
}
