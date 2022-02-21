using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public CustomerController(ICustomerRepository customerRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._customerRepository = customerRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                var customers = await _customerRepository.All();
                return View(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                CustomerInformations customerInformations = new CustomerInformations();

                return PartialView("_Create", customerInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerInformations customerInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View("_Create",customerInformations);
                }
                else
                {
                    if (customerInformations.Id > 0)
                    {
                        customerInformations.IsActive = true;
                        var customerUpdate = await _customerRepository.Update(customerInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = customerInformations.CompanyName,
                            AfterUpdate = customerInformations.CompanyName,
                            UpdateInfo = customerInformations.CompanyName + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", customerUpdate);
                    }
                    else
                    {
                        if (await _customerRepository.TrnExist(customerInformations.TRNNumber))
                        {
                            ModelState.AddModelError("TRNNumber", "The TRN Number " + customerInformations.TRNNumber + " already exist");
                            return View("_Create", customerInformations);
                        }
                        else
                        {

                            customerInformations.CreatedBy = 1;
                            customerInformations.CreatedDate = System.DateTime.Now;
                            customerInformations.IsActive = true;

                            var customer = await _customerRepository.Insert(customerInformations);
                            return PartialView("_Details", customer);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var customer = await _customerRepository.GetById(Id);
                return PartialView("_Details", customer);
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
                var customer = await _customerRepository.GetById(Id);
                return PartialView("_Create", customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var customer = await _customerRepository.GetById(Id);
                return PartialView("_Delete", customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CustomerInformations customerInformations)
        {
            try
            {

                if (customerInformations != null)
                {
                    var customer = await _customerRepository.GetById(customerInformations.Id);

                    customer.IsActive = false;

                    await _customerRepository.Update(customer);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", customerInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}