using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;
        public MockExpenseRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<ExpenseInformation>> All()
        {
            try
            {
               var expenses = await _context.ExpenseInformations
                              .Where(x => x.IsActive == true)
                              .Include("UserInformation")
                              .Include("VenderInformations")
                              .Include("EmployeeInformations")
                              .Include("PaymentTypeInformations")
                              .ToListAsync();

                return expenses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ExpenseInformation> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseInformation> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseInformation> Insert(ExpenseInformation expenseInformation)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseInformation> Update(ExpenseInformation expenseInformation)
        {
            throw new NotImplementedException();
        }
    }
}
