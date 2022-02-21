using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _context;

        public MockEmployeeRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<EmployeeInformations>> All()
        {
            var employess = await _context.EmployeeInformations.ToListAsync();
            return employess;
        }

        public Task<EmployeeInformations> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeInformations> GetById(int Id)
        {
            try
            {
                var employee = await _context.EmployeeInformations.FirstOrDefaultAsync(x => x.Id == Id);
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<EmployeeInformations> Insert(EmployeeInformations employeeInformations)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeInformations> Update(EmployeeInformations employeeInformations)
        {
            throw new NotImplementedException();
        }
    }
}
