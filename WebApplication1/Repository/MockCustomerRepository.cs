using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public MockCustomerRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        
        public async Task<List<CustomerInformations>> All()
        {
            try
            {
                var customers = await _context.CustomerInformations.Where(x => x.IsActive == true).Include("UserInformation").ToListAsync();
                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerInformations> Delete(int Id)
        {
            try
            {
                var customer = await _context.CustomerInformations.FirstOrDefaultAsync(x => x.Id == Id);
                _context.Remove(customer);
                await _context.SaveChangesAsync();

                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> TrnExist(string Trn)
        {
            try
            {
                var Count = await _context.CustomerInformations.Where(x => x.TRNNumber == Trn && x.IsActive == true).CountAsync();

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

        public async Task<CustomerInformations> GetById(int Id)
        {
            try
            {
                var customer = await _context.CustomerInformations.Include("UserInformation").FirstOrDefaultAsync(x => x.Id == Id);
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerInformations> Insert(CustomerInformations customerInformations)
        {
            try
            {
                await _context.AddAsync(customerInformations);
                await _context.SaveChangesAsync();

                CustomerInformations customer = new CustomerInformations();

                if (customerInformations.Id > 0)
                {
                    customer = await _context.CustomerInformations.FirstOrDefaultAsync(x => x.Id == customerInformations.Id);
                    return customer;
                }
                else
                {
                    return customerInformations;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerInformations> Update(CustomerInformations customerInformations)
        {
            try
            {
                var customer = _context.CustomerInformations.Attach(customerInformations);
                customer.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return customerInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
