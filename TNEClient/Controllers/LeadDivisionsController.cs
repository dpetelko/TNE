using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Data;
using TNEClient.Dtos;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class LeadDivisionsController : Controller
    {
        private const string SuccessMessage = "SuccessMessage";
        private const string CreateSuccess = "Головное подразделение успешно создано!";
        private const string UpdateSuccess = "Головное подразделение успешно изменено!";
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

        // GET: LeadDivisionsController/Delete/5
        public async Task<ActionResult> Undelete(Guid id)
        {
            await _service.UndeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: LeadDivisionsController/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

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
