using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductInfo>> All();
        Task<ProductInfo> Insert(ProductInfo productInfo);
        Task<ProductInfo> GetById(int Id);
        Task<ProductInfo> Update(ProductInfo productInfo);
        Task<ProductInfo> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
