using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Interfaces
{
    public interface ITransictionRepository
    {
        Task<List<TransictionInformations>> All();
        Task<List<TransictionInformations>> Insert(List<TransictionInformations> transictionInformations);
        Task<TransictionInformations> GetById(int Id);
        Task<TransictionInformations> Update(TransictionInformations transictionInformations);
        Task<TransictionInformations> Delete(int Id);
        Task<List<TransictionInformations>> GetByUniqueIdentity(int Id);
        Task<List<TransictionTrailBalance>> GetTrailBalance();
    }
}
