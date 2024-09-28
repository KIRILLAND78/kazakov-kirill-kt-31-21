using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace kazakov_kirill_kt_31_21.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfessorController : Controller
    {

        private readonly ILogger<ProfessorController> _logger;
        private readonly IProfessorService _professorService;
        //private readonly  _logger;
        public ProfessorController(ILogger<ProfessorController> logger, IProfessorService professorService)
        {
            _logger = logger;
            _professorService = professorService;
        }
        [HttpPost(Name = "GetProfessorsByFilter")]
        public async Task<IActionResult> GetProfessorsByFilterAsync(ProfessorGroupFilter filter, CancellationToken cancellationToken = default)
        {

            return Ok(await _professorService.GetProfessorsByFilterAsync(filter, cancellationToken));
        }
    }
}
