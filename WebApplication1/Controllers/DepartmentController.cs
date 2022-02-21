using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public DepartmentController(IDepartmentRepository departmentRepository, ITrackUpdateRepository trackUpdateRepository)
        {
            this._departmentRepository = departmentRepository;
            this._trackUpdateRepository = trackUpdateRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var departments = await _departmentRepository.All();
                return View(departments);
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
                DepartmentInformations departmentInformations = new DepartmentInformations();

                return PartialView("_Create", departmentInformations);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentInformations departmentInformations)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(departmentInformations);
                }
                else
                {
                    if (departmentInformations.Id > 0)
                    {
                        departmentInformations.IsActive = true;
                        var departmentUpdate = await _departmentRepository.Update(departmentInformations);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = departmentInformations.Name,
                            AfterUpdate = departmentInformations.Name,
                            UpdateInfo = departmentInformations.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        return PartialView("_Details", departmentUpdate);
                    }
                    else
                    {
                        if (await _departmentRepository.Exist(departmentInformations.Name))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + departmentInformations.Name + " already exist");
                            return View();
                        }
                        else
                        {

                            departmentInformations.CreatedBy = 1;
                            departmentInformations.CreatedDate = System.DateTime.Now;
                            departmentInformations.IsActive = true;

                            var department = await _departmentRepository.Insert(departmentInformations);
                            return PartialView("_Details", department);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var departments = await _departmentRepository.GetById(Id);
                return PartialView("_Details", departments);
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
                var Department = await _departmentRepository.GetById(Id);
                return PartialView("_Create", Department);
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
                var Department = await _departmentRepository.GetById(Id);
                return PartialView("_Delete", Department);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentInformations departmentInformations)
        {
            try
            {
              
                if (departmentInformations != null)
                {
                    var dep = await _departmentRepository.GetById(departmentInformations.Id);

                    dep.IsActive = false;

                    await _departmentRepository.Update(dep);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", departmentInformations);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}