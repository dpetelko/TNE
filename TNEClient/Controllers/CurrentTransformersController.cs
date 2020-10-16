using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class CurrentTransformersController : Controller
    {
        private const string UpdateSuccess = "Трансформатор тока успешно изменен!";
        private const string CreateSuccess = "Трансформатор тока успешно создан!";
        private const string SuccessMessage = "SuccessMessage";
        private readonly ICurrentTransformerService _service;

        public CurrentTransformersController(ICurrentTransformerService service) { _service = service; }

        // GET: CurrentTransformersController
        public async Task<ActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
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
            Log.Error("!!!!!!!!!!!!!!Incomming form {form}", form);
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(form);
                TempData[SuccessMessage] = CreateSuccess;
                return RedirectToAction(nameof(Index));
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
                await _service.UpdateAsync(form);
                TempData[SuccessMessage] = UpdateSuccess;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
