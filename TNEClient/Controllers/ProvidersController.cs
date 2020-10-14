using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Serilog;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly IProviderService _providerService;
        private readonly ISubDivisionService _subDivisionService;
        private readonly IControlPointService _controlPointService;
        private readonly IDeliveryPointService _deliveryPointService;

        public ProvidersController(IProviderService providerService,
            ISubDivisionService subDivisionService,
            IControlPointService controlPointService,
            IDeliveryPointService deliveryPointService)
        {
            _providerService = providerService;
            _subDivisionService = subDivisionService;
            _controlPointService = controlPointService;
            _deliveryPointService = deliveryPointService;
        }

        // GET: ProvidersController
        public async Task<IActionResult> Index()
        {
            return View(await _providerService.GetAllAsync());
        }

        // GET: ProvidersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.ControlPointList = await _controlPointService.GetAllDtoByProviderIdAsync(id);
            ViewBag.DeliveryPointList = await _deliveryPointService.GetAllDtoByProviderIdAsync(id);
            return View(await _providerService.GetAsync(id));
        }

        // GET: ProvidersController/Create
        public async Task<ActionResult> Create()
        {
            await GetSubDivisionList();
            return View();
        }

        // POST: ProvidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProviderDto form)
        {
            if (ModelState.IsValid)
            {
                await _providerService.CreateAsync(form);
                TempData["SuccessMessage"] = "Объект потребления успешно создан!";
                return RedirectToAction(nameof(Index));
            }
            await GetSubDivisionList();
            return View();
        }

        // GET: ProvidersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetSubDivisionList();
            return View(await _providerService.GetAsync(id));
        }

        // POST: ProvidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProviderDto form)
        {
            if (ModelState.IsValid)
            {
                await _providerService.UpdateAsync(form);
                TempData["SuccessMessage"] = "Объект потребления успешно изменен!";
                return RedirectToAction(nameof(Index));
            }
            await GetSubDivisionList();
            return View();
        }

        // GET: ProvidersController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _providerService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProvidersController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _providerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetSubDivisionList()
        {
            ViewBag.SubDivisionList = new SelectList(await _subDivisionService.GetAllAsync(), "Id", "Name");
        }
    }
}
