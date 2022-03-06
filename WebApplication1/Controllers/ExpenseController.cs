using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IVenderRepository _venderRepository;

        public ExpenseController(IExpenseRepository expenseRepository, IProductRepository productRepository,
            IVenderRepository venderRepository)
        {
            this._expenseRepository = expenseRepository;
            this._productRepository = productRepository;
            this._venderRepository = venderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var expenses = await _expenseRepository.All();
                return View(expenses);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
               List<ExpenseDetailsInformations> expenseDetails = new List<ExpenseDetailsInformations>();
                expenseDetails[0].ExpenseInformation.ExpenseNumber = 06032002;

                 ViewBag.Products = await GetProducts();
                 ViewBag.Venders = await GetVenders();

                return View(expenseDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<ProductInfo>> GetProducts()
        {
            try
            {
                var  products =  await _productRepository.All();
                products.Insert(0, new ProductInfo() { Id = 0, Name = "Please select Product" });
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        public async Task<List<VenderInformations>> GetVenders()
        {
            try
            {
                var venders = await _venderRepository.All();
                venders.Insert(0, new VenderInformations() { Id=0, CompanyName = "Please select Vender" });
                return venders;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}