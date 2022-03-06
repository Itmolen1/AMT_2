using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<ExpenseInformation>> All();
        Task<ExpenseInformation> Insert(ExpenseInformation expenseInformation);
        Task<ExpenseInformation> GetById(int Id);
        Task<ExpenseInformation> Update(ExpenseInformation expenseInformation);
        Task<ExpenseInformation> Delete(int Id);
        Task<bool> Exist(string Name);
    }
}
