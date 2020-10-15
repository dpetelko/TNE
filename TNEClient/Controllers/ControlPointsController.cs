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
    public class ControlPointsController : Controller
    {
        private const string CreateSuccess = "Точка контроля электроэнергии успешно создана!";
        private const string UpdateSuccess = "Точка контроля электроэнергии успешно изменена!";
        private const string SuccessMessage = "SuccessMessage";
        private readonly IControlPointService _controlPointService;
        private readonly IBillingPointService _billingPointService;
        private readonly IProviderService _providerService;
        private readonly IVoltageTransformerService _voltageTransformerService;
        private readonly ICurrentTransformerService _currentTransformerService;
        private readonly IElectricityMeterService _electricityMeterService;

        public ControlPointsController(IControlPointService controlPointService,
            IBillingPointService billingPointService,
            IProviderService providerService,
            IVoltageTransformerService voltageTransformerService,
            ICurrentTransformerService currentTransformerService,
            IElectricityMeterService electricityMeterService)
        {
            _controlPointService = controlPointService;
            _billingPointService = billingPointService;
            _providerService = providerService;
            _voltageTransformerService = voltageTransformerService;
            _currentTransformerService = currentTransformerService;
            _electricityMeterService = electricityMeterService;
        }

        // GET: ControlPointsController
        public async Task<IActionResult> Index()
        {
            return View(await _controlPointService.GetAllAsync());
        }

        // GET: ControlPointsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.BillingPointList = await _billingPointService.GetAllDtoByControlPointIdAsync(id);
            return View(await _controlPointService.GetAsync(id));
        }

        // GET: ControlPointsController/Create
        public async Task<ActionResult> Create()
        {
            await GetDevicesList();
            return View();
        }

        // POST: ControlPointsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ControlPointDto form)
        {
            if (ModelState.IsValid)
            {
                await _controlPointService.CreateAsync(form);
                TempData[SuccessMessage] = CreateSuccess;
                return RedirectToAction(nameof(Index));
            }
            await GetDevicesList();
            return View();
        }

        // GET: ControlPointsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetDevicesList();
            return View(await _controlPointService.GetAsync(id));
        }

        // POST: ControlPointsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ControlPointDto form)
        {
            if (ModelState.IsValid)
            {
                await _controlPointService.UpdateAsync(form);
                TempData[SuccessMessage] = UpdateSuccess;
                return RedirectToAction(nameof(Index));
            }
            await GetDevicesList();
            return View();
        }

        // GET: ControlPointsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _controlPointService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ControlPointsController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _controlPointService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetDevicesList()
        {
            ViewBag.ProviderList = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
            ViewBag.VoltageTransformerList = await _voltageTransformerService.GetAllByStatusAsync(Status.InStorage);
            ViewBag.CurrentTransformerList = await _currentTransformerService.GetAllByStatusAsync(Status.InStorage);
            ViewBag.ElectricityMeterList = await _electricityMeterService.GetAllByStatusAsync(Status.InStorage);
        }
    }
}
