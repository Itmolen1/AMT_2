using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MockQuotationRepository : IQuotationRepository
    {
        private readonly AppDbContext _context;

        public MockQuotationRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<List<QuotationInformation>> All()
        {
            var quotations = await _context.QuotationInformation
                .Where(x => x.IsActive == true)
                .OrderByDescending(x=>x.Id)
                .Include(x=>x.UserInformation)
                .Include(x=>x.CustomerInformations)
                .ToListAsync();
            return quotations;
        }

        public Task<QuotationInformation> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuotationDetails>> GetById(int Id)
        {
            try
            {
                var quotationDetails = await _context.QuotationDetails
                    .Where(x => x.QuotationId == Id)
                    .OrderBy(x=>x.Id)
                    .Include(x=>x.ProductInfo)
                    .Include(x=>x.UnitInformations)
                    .Include(x=>x.QuotationInformation)
                    .Include(x=>x.QuotationInformation.UserInformation)
                    .Include(x=>x.QuotationInformation.CustomerInformations)
                    .ToListAsync();

                return quotationDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetQuotationNumber()
        {
            try
            {
                int QNumber = 0;
                QNumber = await _context.QuotationInformation.Select(x => x.QuotationNumber).LastOrDefaultAsync();
                return QNumber;
            }
            catch (Exception)
            {
                throw;
            }
        } 

        public async Task<QuotationInformation> Insert(QuotationInformation quotationInformation)
        {
            try
            {
                await _context.AddAsync(quotationInformation);
                await _context.SaveChangesAsync();
                return quotationInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QuotationInformation> QuotationAccept(int Id)
        {
            try
            {
                var quotation = await _context.QuotationInformation.Where(x => x.Id == Id).FirstOrDefaultAsync();
                quotation.ISConverted = true;
                _context.Entry(quotation).Property(x => x.ISConverted).IsModified = true;
                await _context.SaveChangesAsync();
                
                return quotation;   
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<QuotationInformation> Update(QuotationInformation quotationInformation)
        {
            try
            {                
                var quotation =  _context.QuotationInformation.Attach(quotationInformation);
                quotation.State = EntityState.Modified;
                await _context.SaveChangesAsync();

                if(quotationInformation.QuotationDetails.Where(x=>x.Id > 0).Count() > 0)
                {
                    foreach(var item in quotationInformation.QuotationDetails.Where(x => x.Id > 0))
                    {
                        var QdtailsObj = _context.QuotationDetails.Attach(item);
                        QdtailsObj.State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                return quotationInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
