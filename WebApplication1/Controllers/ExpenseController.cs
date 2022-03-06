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
        private readonly IEmployeeRepository _employeeRepository;

        public ExpenseController(IExpenseRepository expenseRepository, IProductRepository productRepository,
            IVenderRepository venderRepository, IEmployeeRepository employeeRepository)
        {
            this._expenseRepository = expenseRepository;
            this._productRepository = productRepository;
            this._venderRepository = venderRepository;
            this._employeeRepository = employeeRepository;
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
                ExpenseInformation expenseInformation = new ExpenseInformation();
                expenseInformation.ExpenseNumber = 06032002;

                ViewBag.Products = await GetProducts();
                ViewBag.Venders = await GetVenders();
                ViewBag.employees = await GetEmployees();
                expenseInformation.ExpenseDate = System.DateTime.Now;

                return PartialView("_Create",expenseInformation);
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
                var products = await _productRepository.All();
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
                venders.Insert(0, new VenderInformations() { Id = 0, CompanyName = "Please select Vender" });
                return venders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<EmployeeInformations>> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepository.All();
                employees.Insert(0, new EmployeeInformations() { Id = 0, Name = "Please select employee" });
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}