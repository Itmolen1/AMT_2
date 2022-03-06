using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IQuotationRepository
    {
        Task<List<QuotationInformation>> All();
        Task<QuotationInformation> Insert(QuotationInformation quotationInformation);
        Task<List<QuotationDetails>> GetById(int Id);
        Task<QuotationInformation> Update(QuotationInformation quotationInformation);
        Task<QuotationInformation> Delete(int Id);
        Task<int> GetQuotationNumber();
        Task<QuotationInformation> QuotationAccept(int Id);

    }
}
