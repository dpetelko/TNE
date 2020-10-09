using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: VoltageTransformersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.HeadLine = "Создание нового транформатора напряжения";
            ViewBag.VoltageTransformer = new VoltageTransformerDto();
            return View();
        }

        // POST: VoltageTransformersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoltageTransformersController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: VoltageTransformersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoltageTransformersController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: VoltageTransformersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
