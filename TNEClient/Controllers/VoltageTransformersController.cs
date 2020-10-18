using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class VoltageTransformersController : Controller
    {
        private const string SuccessMessage = "SuccessMessage";
        private const string CreateSuccess = "Трансформатор напряжения успешно создан!";
        private const string UpdateSuccess = "Трансформатор напряжения успешно изменен!";
        private readonly IVoltageTransformerService _service;
        private readonly IProviderService _providerService;

        public VoltageTransformersController(IVoltageTransformerService service, IProviderService providerService)
        {
            _service = service;
            _providerService = providerService;
        }

        // GET: VoltageTransformersController
        public async Task<ActionResult> Index(DeviceCalibrationControlDto filter)
        {
            await GetProviderList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(await _service.GetAllDtoByFilterAsync(filter));
        }

        // GET: VoltageTransformersController/Details/5
        public async Task<ActionResult> Details(Guid id) => View(await _service.GetAsync(id));

        // GET: VoltageTransformersController/Create
        public ActionResult Create() => View();

        // POST: VoltageTransformersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VoltageTransformerDto form)
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

        // GET: VoltageTransformersController/Edit/5
        public async Task<ActionResult> Edit(Guid id) => View(await _service.GetAsync(id));

        // POST: VoltageTransformersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VoltageTransformerDto form)
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
