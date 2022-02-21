using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {

        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeRepository.All();
                return View(employees);
            }
            catch (Exception)
            {

                throw;
            }
         
        }
        
        public async Task<IActionResult> Create(EmployeeInformations employeeInformation)
        {
            try
            {
                var employee = await _employeeRepository.Insert(employeeInformation);
                return base.View("Details",(object)employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
               
        public async Task<IActionResult> Update(EmployeeInformations employeeInformation)
        {
            try
            {
                var employee = await _employeeRepository.Update(employeeInformation);
                return View("Details", employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var employee = await _employeeRepository.GetById(Id);
                return View(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var employee = await _employeeRepository.Delete(Id);
                return View("Details",employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}