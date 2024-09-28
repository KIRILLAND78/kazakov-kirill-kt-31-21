using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces
{
    public interface IFacultyService
    {
        public Faculty DeleteFaculty(long id, CancellationToken cancellationToken);
    }
    public class FacultyService : IFacultyService
    {
        private readonly UniversityDbContext _dbContext;
        public FacultyService(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Faculty DeleteFaculty(long id, CancellationToken cancellationToken = default)
        {
            Faculty faculty = _dbContext.Faculties.Find(id);
            _dbContext.Remove(faculty);
            return faculty;
        }
    }
}
