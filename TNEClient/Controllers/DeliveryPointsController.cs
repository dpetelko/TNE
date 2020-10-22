using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class DeliveryPointsController : Controller
    {
        private const string UpdateSuccess = "Точка поставки успешно изменена!";
        private const string CreateSuccess = "Точка поставки тока успешно создана!";
        private const string SuccessMessage = "SuccessMessage";
        private readonly IDeliveryPointService _deliveryPointService;
        private readonly IProviderService _providerService;
        private readonly IBillingPointService _billingPointService;

        public DeliveryPointsController(IDeliveryPointService deliveryPointService,
            IProviderService providerService,
            IBillingPointService billingPointService)
        {
            _deliveryPointService = deliveryPointService;
            _providerService = providerService;
            _billingPointService = billingPointService;
        }

        // GET: DeliveryPointsController
        public async Task<IActionResult> Index()
        {
            return View(await _deliveryPointService.GetAllAsync());
        }

        // GET: DeliveryPointsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.BillingPointList = await _billingPointService.GetAllDtoByDeliveryPointIdAsync(id);
            return View(await _deliveryPointService.GetAsync(id));
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
                try
                {
                    await _deliveryPointService.CreateAsync(form);
                    TempData[SuccessMessage] = CreateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
            }
            await GetProviderList();
            return View();
        }

        // GET: DeliveryPointsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetProviderList();
            return View(await _deliveryPointService.GetAsync(id));
        }

        // POST: DeliveryPointsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DeliveryPointDto form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _deliveryPointService.UpdateAsync(form);
                    TempData[SuccessMessage] = UpdateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
            }
            await GetProviderList();
            return View();
        }

        // GET: DeliveryPointsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _deliveryPointService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: DeliveryPointsController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _deliveryPointService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetProviderList()
        {
            ViewBag.ProviderList = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
        }

        private void GetRestValidationErrors(ValidationApiException ex)
        {
            var errors = ex.Content.Errors;
            foreach (var (key, value) in from pair in errors
                                         let key = pair.Key
                                         let values = pair.Value
                                         from value in values
                                         select (key, value))
            {
                ModelState.AddModelError(key, value);
            }
        }
    }
}
