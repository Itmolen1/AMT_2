using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockHomeRepository : IHomeRepository
    {
        private readonly AppDbContext _context;

        public MockHomeRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        
        public async Task<WidgetsViewModel> GetWidgets()
        {
            WidgetsViewModel widgetsViewModel = new WidgetsViewModel();

            widgetsViewModel.TotalEmployee = await _context.EmployeeInformations.Where(x=>x.IsActive == true).CountAsync();
            widgetsViewModel.TotalVehicle = await _context.VehicleInformation.Where(x=>x.IsActive == true).CountAsync();
            widgetsViewModel.TotalInvoice = 10;
            widgetsViewModel.TotalQuotaion = await _context.QuotationInformation.Where(x=>x.IsActive == true).CountAsync();

            return widgetsViewModel;
        }
    }
}
