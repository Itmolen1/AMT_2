using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TrackUpdateController : Controller
    {
        private readonly ITrackUpdateRepository _trackUpdateRepository;

        public TrackUpdateController(ITrackUpdateRepository trackUpdate)
        {
            this._trackUpdateRepository = trackUpdate;
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                var designations = await _trackUpdateRepository.All();
                return View(designations);

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
                var designation = await _trackUpdateRepository.GetById(Id);
                return PartialView("_Delete", designation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TrackUpdateInformations trackUpdateInformations)
        {
            try
            {

                if (trackUpdateInformations != null)
                {
                    var trackUpdate = await _trackUpdateRepository.GetById(trackUpdateInformations.Id);

                    trackUpdate.IsActive = false;

                    await _trackUpdateRepository.Update(trackUpdate);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", _trackUpdateRepository);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}