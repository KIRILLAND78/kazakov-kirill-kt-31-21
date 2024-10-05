using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.DTO;
using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_kirill_kt_31_21.Interfaces.FacultyInterfaces
{
    public interface IFacultyService
    {
        public Faculty? DeleteFaculty(long id, CancellationToken cancellationToken);
        public Faculty CreateFaculty(FacultyDTO facultyDTO, CancellationToken cancellationToken);
        public Task<List<Faculty>> IndexFacultyAsync(CancellationToken cancellationToken);
    }
    public class FacultyService : IFacultyService
    {
        private readonly UniversityDbContext _dbContext;
        public FacultyService(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Faculty? DeleteFaculty(long id, CancellationToken cancellationToken = default)
        {
            Faculty faculty = _dbContext.Faculties.Find(id);
            if (faculty is null) throw new Exception("Не найдена кафедра");
            _dbContext.Remove(faculty);
            _dbContext.SaveChanges();
            return faculty;
        }

        public Faculty CreateFaculty(FacultyDTO facultyDTO, CancellationToken cancellationToken = default)
        {
            Faculty faculty = new Faculty() { Name = facultyDTO.Name};
            _dbContext.Add(faculty);
            _dbContext.SaveChanges();
            return faculty;
        }

        public Task<List<Faculty>> IndexFacultyAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Faculties.ToListAsync();
        }
    }
}
