using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ICustomerRepository _customerRepository;

        public QuotationController(IQuotationRepository quotationRepository,
            ITrackUpdateRepository trackUpdateRepository, IProductRepository productRepository,
            IUnitRepository unitRepository, ICustomerRepository customerRepository)
        {
            this._quotationRepository = quotationRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._productRepository = productRepository;
            this._unitRepository = unitRepository;
            this._customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var quotations = await _quotationRepository.All();
                return View(quotations);
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
                QuotationInformation quotationInformation = new QuotationInformation();

                ViewBag.Customers = await GetCustomers();
                ViewBag.Products = await GetProductInfos();
                ViewBag.Units = await GetUnitInfo();
                quotationInformation.QuotationNumber = await QuotationNumber();
                quotationInformation.TotalAmount = (float)0.00;
                quotationInformation.VAT = (float)0.00;
                quotationInformation.GrandTotalAmount = (float)0.00;
                quotationInformation.FromDate = System.DateTime.Now;

                return PartialView("_Create", quotationInformation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuotationInformation quotationInformation)
        {
            try
            {
                quotationInformation.CreatedBy = 1;
                quotationInformation.CreatedDate = System.DateTime.Now;
                quotationInformation.IsActive = true;
                quotationInformation.ISConverted = false;

                var QuotationObj = await _quotationRepository.Insert(quotationInformation);

                if (QuotationObj.Id > 0)
                    return Json(QuotationObj.Id);
                else
                    return Json("Failed");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuotationInformation quotationInformation)
        {
            try
            {
                quotationInformation.CreatedBy = 1;
                quotationInformation.CreatedDate = System.DateTime.Now;
                var QuotationObj = await _quotationRepository.Update(quotationInformation);
                      
                if (QuotationObj.Id > 0)
                    return Json(QuotationObj.Id);
                else
                    return Json("Failed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var quotationDetails = await _quotationRepository.GetById(Id);
                return PartialView("_Details", quotationDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                ViewBag.Customers = await GetCustomers();
                ViewBag.Products = await GetProductInfos();
                ViewBag.Units = await GetUnitInfo();

                QuotationInformation quotation = new QuotationInformation();

                var quotationDetails = await _quotationRepository.GetById(Id);
                if (quotationDetails.Count > 0)
                {
                    quotation = quotationDetails[0].QuotationInformation;
                }
                ViewBag.quotationDetail = quotationDetails;

                return PartialView("_Create", quotation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> PrintQuotation(int Id)
        {
            try
            {
                var quotationDetails = await _quotationRepository.GetById(Id);
                return PartialView("_PrintQuotation", quotationDetails);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<ProductInfo>> GetProductInfos()
        {
            try
            {
                var products = await _productRepository.All();
                products.Insert(0, new ProductInfo() { Id = 0, Name = "Select Product" });

                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<UnitInformations>> GetUnitInfo()
        {
            try
            {
                var units = await _unitRepository.All();
                units.Insert(0, new UnitInformations() { Id = 0, Name = "Select Unit" });

                return units;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<CustomerInformations>> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.All();

                customers.Insert(0, new CustomerInformations() { Id = 0, CompanyName = "Select Customer" });

                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptQuotation(int Id)
        {
            try
            {
                var quotationObj = await _quotationRepository.QuotationAccept(Id);
                return Json("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> QuotationNumber()
        {
            try
            {
                int num = await _quotationRepository.GetQuotationNumber();
                return num;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}