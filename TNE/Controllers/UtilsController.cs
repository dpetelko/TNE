using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNE.Services;

namespace TNE.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        private readonly IDbGenerator _generator;
        public UtilsController(IDbGenerator generator) => _generator = generator;

        [HttpGet]
        public async Task<ActionResult> Generate()
        {
            await _generator.Start();
            return Ok();
        }
    }
}