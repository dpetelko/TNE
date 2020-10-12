using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TNEClient.Data;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class LeadDivisionsController : Controller
    {
        private readonly ILeadDivisionService _service;
        private readonly ISubDivisionRepository _subRepo;

        public LeadDivisionsController(ILeadDivisionService service, ISubDivisionRepository subRepo)
        {
            _service = service;
            _subRepo = subRepo;
        }

        // GET: LeadDivisionsController
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: LeadDivisionsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var subDivisionList = await _subRepo.GetByLeadDivisionAsync(id);
            ViewBag.SubDivisionList = subDivisionList;
            return View(await _service.GetAsync(id));
        }

        // GET: LeadDivisionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadDivisionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeadDivisionDto form)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: LeadDivisionsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _service.GetAsync(id));
        }

        // POST: LeadDivisionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeadDivisionDto form)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: LeadDivisionsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _service.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: LeadDivisionsController/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
