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
    public class ProvidersController : Controller
    {
        private readonly IProviderService _ProviderService;
        private readonly ISubDivisionService _subDivisionService;

        public ProvidersController(IProviderService ProviderService, ISubDivisionService subDivisionService)
        {
            _ProviderService = ProviderService;
            _subDivisionService = subDivisionService;
        }


        // GET: ProvidersController
        public async Task<IActionResult> Index()
        {
            return View(await _ProviderService.GetAllAsync());
        }

        // GET: ProvidersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _ProviderService.GetAsync(id));
        }

        // GET: ProvidersController/Create
        public async Task<ActionResult> Create()
        {
            await GetSubDivisionList();
            return View();
        }

        // POST: ProvidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProviderDto form)
        {
            if (ModelState.IsValid)
            {
                await _ProviderService.CreateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            await GetSubDivisionList();
            return View();
        }

        // GET: ProvidersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            await GetSubDivisionList();
            return View(await _ProviderService.GetAsync(id));
        }

        // POST: ProvidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProviderDto form)
        {
            if (ModelState.IsValid)
            {
                await _ProviderService.UpdateAsync(form);
                return RedirectToAction(nameof(Index));
            }
            await GetSubDivisionList();
            return View();
        }

        // GET: ProvidersController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _ProviderService.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProvidersController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _ProviderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        private async Task GetSubDivisionList()
        {
            ViewBag.SubDivisionList = new SelectList(await _subDivisionService.GetAllAsync(), "Id", "Name");
        }
    }
}
