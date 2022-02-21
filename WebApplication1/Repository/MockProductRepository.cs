using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public MockProductRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<ProductInfo>> All()
        {
            try
            {
                var products = await _context.ProductInfos.Where(x => x.IsActive == true).Include("UserInformation").Include("UnitInformations").ToListAsync();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductInfo> Delete(int Id)
        {
            try
            {
                var product = await _context.ProductInfos.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Exist(string Name)
        {
            try
            {
                var Count = await _context.ProductInfos.Where(x => x.Name == Name && x.IsActive == true).CountAsync();

                if (Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductInfo> GetById(int Id)
        {
            try
            {
                var product = await _context.ProductInfos.Include("UserInformation").Include("UnitInformations").FirstOrDefaultAsync(x => x.Id == Id);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductInfo> Insert(ProductInfo productInfo)
        {
            try
            {
                await _context.AddAsync(productInfo);
                await _context.SaveChangesAsync();

                ProductInfo product = new ProductInfo();

                if (productInfo.Id > 0)
                {
                    product = await _context.ProductInfos.FirstOrDefaultAsync(x => x.Id == productInfo.Id);
                    return product;
                }
                else
                {
                    return productInfo;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductInfo> Update(ProductInfo productInfo)
        {
            try
            {
                var product = _context.ProductInfos.Attach(productInfo);
                product.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return productInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
