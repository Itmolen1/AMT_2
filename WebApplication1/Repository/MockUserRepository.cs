using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public MockUserRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<UserInformation>> All()
        {
            try
            {
                var users = await _context.UserInformations.ToListAsync();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<UserInformation> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformation> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformation> Insert(UserInformation userInformation)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformation> Update(UserInformation userInformation)
        {
            throw new NotImplementedException();
        }
    }
}
