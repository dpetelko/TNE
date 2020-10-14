using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class ElectricityMetersController : Controller
    {
        private readonly IElectricityMeterService _service;

        public ElectricityMetersController(IElectricityMeterService service) { _service = service; }

        // GET: ElectricityMetersController
        public async Task<ActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
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
                await _service.CreateAsync(form);
                TempData["SuccessMessage"] = "Счетчик электроэнергии успешно создан!";
                return RedirectToAction(nameof(Index));
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
                await _service.UpdateAsync(form);
                TempData["SuccessMessage"] = "Счетчик электроэнергии успешно изменен!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
