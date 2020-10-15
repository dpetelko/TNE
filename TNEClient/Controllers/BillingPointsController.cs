using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class BillingPointsController : Controller
    {
        private const string CreateSuccess = "Расчетный прибор учета успешно создан!";
        private const string UpdateSuccess = "Расчетный прибор учета успешно изменён!";
        private const string SuccessMessage = "SuccessMessage";
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
        public async Task<IActionResult> Index(BillingPointFilter filter)
        {
            await GetPointList();
            return (filter.IsEmpty())
                ? View(await _BillingPointService.GetAllAsync())
                : View(await _BillingPointService.GetAllDtoByFilterAsync(filter));
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
            return View();
        }

        // POST: BillingPointsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BillingPointDto form)
        {
            var qq = JsonConvert.SerializeObject(form);
            Log.Error("Incomming model is - {qq}", qq);
            if (ModelState.IsValid)
            {
                await _BillingPointService.CreateAsync(form);
                TempData[SuccessMessage] = CreateSuccess;
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
                TempData[SuccessMessage] = UpdateSuccess;
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
