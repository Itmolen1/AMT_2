using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepository;
        public readonly ITrackUpdateRepository _trackUpdateRepository;
        public readonly IUnitRepository _unitRepository;

        public ProductController(IProductRepository productRepository,ITrackUpdateRepository trackUpdateRepository,IUnitRepository unitRepository)
        {
            this._productRepository = productRepository;
            this._trackUpdateRepository = trackUpdateRepository;
            this._unitRepository = unitRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var productInfos = await _productRepository.All();
                return View(productInfos);
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
                List<UnitInformations> unitInformations = new List<UnitInformations>();
                unitInformations = await _unitRepository.All();
                unitInformations.Insert(0, new UnitInformations { Id = 0, Name = "Please select unit" });
                ViewBag.unitInformations = unitInformations;
                ProductInfo productInfo = new ProductInfo();

                return PartialView("_Create", productInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInfo productInfo)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(productInfo);
                }
                else
                {
                    if (productInfo.Id > 0)
                    {
                        productInfo.IsActive = true;
                        var productUpdate = await _productRepository.Update(productInfo);

                        //Track Update Model Start
                        var trackUpdateInformations = new TrackUpdateInformations
                        {
                            BeforeUpdate = productInfo.Name,
                            AfterUpdate = productInfo.Name,
                            UpdateInfo = productInfo.Name + "Changes",
                            CreatedBy = 1,
                            CreatedDate = System.DateTime.Now,
                            IsActive = true,
                        };

                        var result = await _trackUpdateRepository.Insert(trackUpdateInformations);
                        //Track Update Model End

                        productUpdate = await _productRepository.GetById(productUpdate.Id);
                        return PartialView("_Details", productUpdate);
                    }
                    else
                    {
                        if (await _productRepository.Exist(productInfo.Name))
                        {
                            ModelState.AddModelError("Name", "The Department with this name " + productInfo.Name + " already exist");
                            return View();
                        }
                        else
                        {

                            productInfo.CreatedBy = 1;
                            productInfo.CreatedDate = System.DateTime.Now;
                            productInfo.IsActive = true;

                            var product = await _productRepository.Insert(productInfo);
                            return PartialView("_Details", product);
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
                var product = await _productRepository.GetById(Id);
                return PartialView("_Details", product);
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
                List<UnitInformations> unitInformations = new List<UnitInformations>();
                unitInformations = await _unitRepository.All();
                unitInformations.Insert(0, new UnitInformations { Id = 0, Name = "Please select unit" });
                ViewBag.unitInformations = unitInformations;

                var product = await _productRepository.GetById(Id);
                return PartialView("_Create", product);
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
                var product = await _productRepository.GetById(Id);
                return PartialView("_Delete", product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductInfo productInfo)
        {
            try
            {

                if (productInfo != null)
                {
                    var product = await _productRepository.GetById(productInfo.Id);

                    product.IsActive = false;

                    await _productRepository.Update(product);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return PartialView("_Details", productInfo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}