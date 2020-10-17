using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class VoltageTransformersController : Controller
    {
        private const string SuccessMessage = "SuccessMessage";
        private const string CreateSuccess = "Трансформатор напряжения успешно создан!";
        private const string UpdateSuccess = "Трансформатор напряжения успешно изменен!";
        private readonly IVoltageTransformerService _service;

        public VoltageTransformersController(IVoltageTransformerService service) { _service = service; }

        // GET: VoltageTransformersController
        public async Task<ActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        // GET: VoltageTransformersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // GET: VoltageTransformersController/Create
        public ActionResult Create()
        {
            return View();
        }

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
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

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
    }
}
