using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerInformations>> All();
        Task<CustomerInformations> Insert(CustomerInformations customerInformations);
        Task<CustomerInformations> GetById(int Id);
        Task<CustomerInformations> Update(CustomerInformations customerInformations);
        Task<CustomerInformations> Delete(int Id);
        Task<bool> TrnExist(string Name);
    }
}
