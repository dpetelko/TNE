using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class SubDivisionsController : Controller
    {
        private readonly ISubDivisionService _subDivisionService;
        private readonly ILeadDivisionService _leadDivisionService;

        public SubDivisionsController(ISubDivisionService subDivisionService, ILeadDivisionService leadDivisionService)
        {
            _subDivisionService = subDivisionService;
            _leadDivisionService = leadDivisionService;
        }


        // GET: SubDivisionsController
        public async Task<IActionResult> Index()
        {
            return View(await _subDivisionService.GetAllAsync());
        }

        // GET: SubDivisionsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _subDivisionService.GetAsync(id));
        }

        // GET: SubDivisionsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.LeadDivisionList = new SelectList(await _leadDivisionService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: SubDivisionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubDivisionDto form)
        {
            Log.Error("!!!!!!!!!!!!!Incomming DTO - {form}", form);

            if (ModelState.IsValid)
            {
                await _subDivisionService.CreateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LeadDivisionList = new SelectList(await _leadDivisionService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // GET: SubDivisionsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.LeadDivisionList = new SelectList(await _leadDivisionService.GetAllAsync(), "Id", "Name");
            return View(await _subDivisionService.GetAsync(id));
        }

        // POST: SubDivisionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubDivisionDto form)
        {
            if (ModelState.IsValid)
            {
                await _subDivisionService.UpdateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LeadDivisionList = new SelectList(await _leadDivisionService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // GET: SubDivisionsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _subDivisionService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: SubDivisionsController/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _subDivisionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
