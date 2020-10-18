using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class CurrentTransformersController : Controller
    {
        private const string UpdateSuccess = "Трансформатор тока успешно изменен!";
        private const string CreateSuccess = "Трансформатор тока успешно создан!";
        private const string SuccessMessage = "SuccessMessage";
        private readonly ICurrentTransformerService _service;
        private readonly IProviderService _providerService;

        public CurrentTransformersController(ICurrentTransformerService service, IProviderService providerService)
        {
            _service = service;
            _providerService = providerService;
        }

        // GET: CurrentTransformersController
        public async Task<ActionResult> Index(DeviceCalibrationControlDto filter)
        {
            await GetProviderList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(await _service.GetAllDtoByFilterAsync(filter));
        }

        // GET: CurrentTransformersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // GET: CurrentTransformersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentTransformersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CurrentTransformerDto form)
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

        // GET: CurrentTransformersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // POST: CurrentTransformersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CurrentTransformerDto form)
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
