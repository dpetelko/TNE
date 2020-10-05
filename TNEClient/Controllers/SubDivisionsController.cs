using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class SubDivisionsController : Controller
    {
        private readonly ILeadDivisionService _service;

        public SubDivisionsController(ILeadDivisionService service) { }

        // GET: LeadDivisionsController
        public ActionResult Index()
        {
            return View();
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
