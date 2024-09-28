using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace kazakov_kirill_kt_31_21.Controllers
{
    [Route("[controller]/[action]")]
    public class FacultyController : Controller
    {

        private readonly ILogger<FacultyController> _logger;
        private readonly IFacultyService _facultyService;
        //private readonly  _logger;
        public FacultyController(ILogger<FacultyController> logger, IFacultyService facultyService)
        {
            _logger = logger;
            _facultyService = facultyService;
        }
        [HttpPost(Name = "DeleteFaculty")]
        public IActionResult DeleteFaculty(long id, CancellationToken cancellationToken = default)
        {
            return Ok(_facultyService.DeleteFaculty(id, cancellationToken));
        }
    }
}
