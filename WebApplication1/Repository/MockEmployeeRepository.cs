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
            var employess = await _context.EmployeeInformations.Where(x => x.IsActive == true)
                .Include("UserInformation")
                .Include("BloodGroupInformations")
                .Include("DesignationInformations")
                .Include("DepartmentInformations")
                .Include("GenderInformations")
                .ToListAsync();
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

        public async Task<EmployeeInformations> Insert(EmployeeInformations employeeInformations)
        {
            try
            {
                await _context.AddAsync(employeeInformations);
                await _context.SaveChangesAsync();

                EmployeeInformations employee = new EmployeeInformations();

                if (employeeInformations.Id > 0)
                {
                    employee = await _context.EmployeeInformations.FirstOrDefaultAsync(x => x.Id == employeeInformations.Id);
                    return employee;
                }
                else
                {
                    return employeeInformations;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeInformations> Update(EmployeeInformations employeeInformations)
        {
            try
            {
                var employee = _context.EmployeeInformations.Attach(employeeInformations);
                employee.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return employeeInformations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
