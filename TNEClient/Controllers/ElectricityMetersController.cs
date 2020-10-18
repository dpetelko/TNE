using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class ElectricityMetersController : Controller
    {
        private const string CreateSuccess = "Счетчик электроэнергии успешно создан!";
        private const string SuccessMessage = "SuccessMessage";
        private const string UpdateSuccess = "Счетчик электроэнергии успешно изменен!";
        private readonly IElectricityMeterService _service;
        private readonly IProviderService _providerService;

        public ElectricityMetersController(IElectricityMeterService service, IProviderService providerService)
        {
            _service = service;
            _providerService = providerService;
        }

        // GET: ElectricityMetersController
        public async Task<ActionResult> Index(DeviceCalibrationControlDto filter)
        {
            await GetProviderList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(await _service.GetAllDtoByFilterAsync(filter));
        }

        // GET: ElectricityMetersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // GET: ElectricityMetersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectricityMetersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ElectricityMeterDto form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.CreateAsync(form);
                    TempData[SuccessMessage] = CreateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
            }
            return View();
        }

        // GET: ElectricityMetersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // POST: ElectricityMetersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ElectricityMeterDto form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(form);
                    TempData[SuccessMessage] = UpdateSuccess;
                    return RedirectToAction(nameof(Index));
                }
                catch (ValidationApiException ex)
                {
                    GetRestValidationErrors(ex);
                }
            }
            return View();
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
        
        private async Task GetProviderList() => ViewBag.ProviderList = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
    }
}
