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
    public class ProvidersController : Controller
    {
        private const string SuccessMessage = "SuccessMessage";
        private const string CreateSuccess = "Объект потребления успешно создан!";
        private const string UpdateSuccess = "Объект потребления успешно изменен!";
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
                try
                {
                    await _providerService.CreateAsync(form);
                    TempData[SuccessMessage] = CreateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
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
                try
                {
                    await _providerService.UpdateAsync(form);
                    TempData[SuccessMessage] = UpdateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
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
