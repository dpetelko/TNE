using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class LeadDivisionsController : Controller
    {
        private readonly ILeadDivisionService _service;

        public LeadDivisionsController(ILeadDivisionService service) { _service = service; }



        // GET: LeadDivisionsController
        public async Task<IActionResult> Index()
        {
            Log.Error("Hello from LeadDivisionsController!!!!");
            return View("~/Views/LeadDivisions/Index.cshtml", await _service.GetAllAsync());
        }

        // GET: LeadDivisionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeadDivisionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadDivisionsController/Create
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

        // GET: LeadDivisionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeadDivisionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LeadDivisionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeadDivisionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
