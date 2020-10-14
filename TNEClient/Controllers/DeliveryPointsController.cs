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
    public class DeliveryPointsController : Controller
    {
        private readonly IDeliveryPointService _DeliveryPointService;
        private readonly IProviderService _providerService;
        private readonly IBillingPointService _billingPointService;

        public DeliveryPointsController(IDeliveryPointService deliveryPointService,
            IProviderService providerService,
            IBillingPointService billingPointService)
        {
            _DeliveryPointService = deliveryPointService;
            _providerService = providerService;
            _billingPointService = billingPointService;
        }

        // GET: DeliveryPointsController
        public async Task<IActionResult> Index()
        {
            return View(await _DeliveryPointService.GetAllAsync());
        }

        // GET: DeliveryPointsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            //ViewBag.BillingPointList = await _billingPointService.GetAllDtoByDeliveryPointId(id);
            return View(await _DeliveryPointService.GetAsync(id));
        }

        // GET: DeliveryPointsController/Create
        public async Task<ActionResult> Create()
        {
            await GetProviderList();
            return View();
        }

        // POST: DeliveryPointsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeliveryPointDto form)
        {
            if (ModelState.IsValid)
            {
                await _DeliveryPointService.CreateAsync(form);
                TempData["SuccessMessage"] = "Точка поставки электроэнергии успешно создана!";
                return RedirectToAction(nameof(Index));
            }
            await GetProviderList();
            return View();
        }

        // GET: DeliveryPointsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetProviderList();
            return View(await _DeliveryPointService.GetAsync(id));
        }

        // POST: DeliveryPointsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DeliveryPointDto form)
        {
            if (ModelState.IsValid)
            {
                await _DeliveryPointService.UpdateAsync(form);
                TempData["SuccessMessage"] = "Точка поставки электроэнергии успешно изменена!";
                return RedirectToAction(nameof(Index));
            }
            await GetProviderList();
            return View();
        }

        // GET: DeliveryPointsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _DeliveryPointService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: DeliveryPointsController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _DeliveryPointService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetProviderList()
        {
            ViewBag.ProviderList = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
        }
    }
}
