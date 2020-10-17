using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Refit;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using TNEClient.Dtos;
using TNEClient.Dtos.SearchFilters;
using TNEClient.Services;

namespace TNEClient.Controllers
{
    public class DeviceCalibrationControlController : Controller
    {
        
        private readonly IControlPointService _service;
        private readonly IProviderService _providerService;

        public DeviceCalibrationControlController(IControlPointService service, IProviderService providerService)
        {
            _service = service;
            _providerService = providerService;
        }





        // GET: BillingPointsController
        public async Task<IActionResult> CurrentTransformers(DeviceCalibrationControlDto filter)
        {
            await GetPointList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(/*await _service.GetAllDtoByFilterAsync(filter)*/);
        }

        public async Task<IActionResult> VoltageTransformers(DeviceCalibrationControlDto filter)
        {
            await GetPointList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(/*await _service.GetAllDtoByFilterAsync(filter)*/);
        }

        public async Task<IActionResult> ElectricityMeters(DeviceCalibrationControlDto filter)
        {
            await GetPointList();
            return (filter.IsEmpty())
                ? View(await _service.GetAllAsync())
                : View(/*await _service.GetAllDtoByFilterAsync(filter)*/);
        }

        private async Task GetPointList()
        {
            ViewBag.ProviderList = new SelectList(await _providerService.GetAllAsync(), "Id", "Name");
        }

    }
}
