using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountsInformation>> All();
        Task<AccountsInformation> Insert(AccountsInformation accountsInformation);
        Task<AccountsInformation> GetById(int Id);
        Task<AccountsInformation> Update(AccountsInformation accountsInformation);
        Task<AccountsInformation> Delete(int Id);
        Task<List<AccountsInformation>> GetAccountByHeadAccount(int Id);
        Task<int> GetAccountCode(int Id);
        Task<bool> Exist(string Name);
    }
}
