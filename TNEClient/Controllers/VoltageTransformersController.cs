using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class VoltageTransformersController : Controller
    {
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
                await _service.CreateAsync(form);
                TempData["SuccessMessage"] = "Трансформатор напряжения успешно создан!";
                return RedirectToAction(nameof(Index));
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
                await _service.UpdateAsync(form);
                TempData["SuccessMessage"] = "Трансформатор напряжения успешно изменен!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
