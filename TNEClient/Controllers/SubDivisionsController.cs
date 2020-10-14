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
        private const string SuccessMessage = "SuccessMessage";
        private const string CreateSuccess = "Дочернее подразделение успешно создано!";
        private const string UpdateSuccess = "Дочернее подразделение успешно изменено!";
        private readonly ISubDivisionService _subDivisionService;
        private readonly ILeadDivisionService _leadDivisionService;
        private readonly IProviderService _providerService;

        public SubDivisionsController(ISubDivisionService subDivisionService, ILeadDivisionService leadDivisionService, IProviderService providerService)
        {
            _subDivisionService = subDivisionService;
            _leadDivisionService = leadDivisionService;
            _providerService = providerService;
        }

        // GET: SubDivisionsController
        public async Task<IActionResult> Index()
        {
            return View(await _subDivisionService.GetAllAsync());
        }

        // GET: SubDivisionsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.ProviderList = await _providerService.GetAllDtoBySubDivisionIdAsync(id);
            return View(await _subDivisionService.GetAsync(id));
        }

        // GET: SubDivisionsController/Create
        public async Task<ActionResult> Create()
        {
            await GetLeadDivisionList();
            return View();
        }

        // POST: SubDivisionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubDivisionDto form)
        {
            if (ModelState.IsValid)
            {
                await _subDivisionService.CreateAsync(form);
                TempData[SuccessMessage] = CreateSuccess;
                return RedirectToAction(nameof(Index));
            }
            await GetLeadDivisionList();
            return View();
        }

        // GET: SubDivisionsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetLeadDivisionList();
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
                TempData[SuccessMessage] = UpdateSuccess;
                return RedirectToAction(nameof(Index));
            }
            await GetLeadDivisionList();
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _subDivisionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetLeadDivisionList()
        {
            ViewBag.LeadDivisionList = new SelectList(await _leadDivisionService.GetAllAsync(), "Id", "Name");
        }
    }
}
