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
    public class BillingPointsController : Controller
    {
        private readonly IBillingPointService _BillingPointService;
        private readonly IControlPointService _controlPointService;
        private readonly IDeliveryPointService _deliveryPointService;

        public BillingPointsController(IBillingPointService billingPointService,
            IControlPointService controlPointService,
            IDeliveryPointService deliveryPointService)
        {
            _BillingPointService = billingPointService;
            _controlPointService = controlPointService;
            _deliveryPointService = deliveryPointService;
        }

        // GET: BillingPointsController
        public async Task<IActionResult> Index()
        {
            return View(await _BillingPointService.GetAllAsync());
        }

        // GET: BillingPointsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _BillingPointService.GetAsync(id));
        }

        // GET: BillingPointsController/Create
        public async Task<ActionResult> Create()
        {
            await GetPointList();
            return View(new BillingPointDto());
        }

        // POST: BillingPointsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BillingPointDto form)
        {
            var qq =  JsonConvert.SerializeObject(form);
            Log.Error("Incomming model is - {qq}", qq);
            if (ModelState.IsValid)
            {
                await _BillingPointService.CreateAsync(form);
                TempData["SuccessMessage"] = "Точка контроля электроэнергии успешно создана!";
                return RedirectToAction(nameof(Index));
            }
            await GetPointList();
            return View();
        }

        // GET: BillingPointsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetPointList();
            return View(await _BillingPointService.GetAsync(id));
        }

        // POST: BillingPointsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BillingPointDto form)
        {
            if (ModelState.IsValid)
            {
                await _BillingPointService.UpdateAsync(form);
                TempData["SuccessMessage"] = "Точка контроля электроэнергии успешно изменена!";
                return RedirectToAction(nameof(Index));
            }
            await GetPointList();
            return View();
        }

        private async Task GetPointList()
        {
            ViewBag.ControlPointList = new SelectList(await _controlPointService.GetAllAsync(), "Id", "Name");
            ViewBag.DeliveryPointList = new SelectList(await _deliveryPointService.GetAllAsync(), "Id", "Name");
        }
    }
}
