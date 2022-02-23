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
        private readonly ITrackUpdateRepository _trackUpdateRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IBloodGroupRepository _bloodGroupRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,ITrackUpdateRepository trackUpdateRepository, 
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository,IBloodGroupRepository bloodGroupRepository)
        {
            this._employeeRepository = employeeRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._departmentRepository = departmentRepository;
            this._designationRepository = designationRepository;
            this._bloodGroupRepository = bloodGroupRepository;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                EmployeeInformations employeeInformation = new EmployeeInformations();

                ViewBag.Departments = await GetDepartments();
                ViewBag.Designations = await GetDesignations();
                ViewBag.BloogGroups = await GetBloodGroups();

                return View("_Create", employeeInformation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInformations employeeInformations)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Departments = await GetDepartments();
                    ViewBag.Designations = await GetDesignations();
                    ViewBag.BloogGroups = await GetBloodGroups();

                    return View("_Create", employeeInformations);
                }
                else
                {
                    if (employeeInformations.Id > 0)
                    {
                        employeeInformations.IsActive = true;
                        var employeeUpdate = await _employeeRepository.Update(employeeInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = employeeInformations.Name,
                            AfterUpdate = employeeInformations.Name,
                            UpdateInfo = employeeInformations.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End
                        return PartialView("_Details", employeeUpdate);
                    }
                    else
                    {
                        employeeInformations.CreatedBy = 1;
                        employeeInformations.CreatedDate = System.DateTime.Now;
                        employeeInformations.IsActive = true;

                        var employee = await _employeeRepository.Insert(employeeInformations);
                        return PartialView("_Details", employee);

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
                var employee = await _employeeRepository.GetById(Id);
                return PartialView("_Details", employee);
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
                ViewBag.Departments = await GetDepartments();
                ViewBag.Designations = await GetDesignations();
                ViewBag.BloogGroups = await GetBloodGroups();

                var employee = await _employeeRepository.GetById(Id);
                return PartialView("_Create", employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<DepartmentInformations>> GetDepartments()
        {
            try
            {
                List<DepartmentInformations> departments = new List<DepartmentInformations>();
                departments = await _departmentRepository.All();
                departments.Insert(0, new DepartmentInformations { Id = 0, Name = "Select Department" });
                return departments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<DesignationInformations>> GetDesignations()
        {
            try
            {
                List<DesignationInformations> designations = new List<DesignationInformations>();
                designations = await _designationRepository.All();
                designations.Insert(0, new DesignationInformations() { Id = 0, Name = "Please select Designation" });
                return designations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public async Task<List<BloodGroupInformations>> GetBloodGroups()
        {
            try
            {
                List<BloodGroupInformations> bloodGroups = new List<BloodGroupInformations>();
                bloodGroups = await _bloodGroupRepository.All();
                if (bloodGroups.Count < 1)
                {
                    bloodGroups.Insert(0, new BloodGroupInformations() { Id = 1, Name = "Unknown" });
                }
                return bloodGroups;                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}