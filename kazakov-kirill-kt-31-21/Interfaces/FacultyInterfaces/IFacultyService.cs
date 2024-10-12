using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.DTO;
using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kazakov_kirill_kt_31_21.Interfaces.FacultyInterfaces
{
    public interface IFacultyService
    {
        public Task<Faculty?> DeleteFaculty(long id, CancellationToken cancellationToken);
        public Task<Faculty> CreateFaculty(FacultyDTO facultyDTO, CancellationToken cancellationToken);
        public Task<Faculty[]> IndexFacultyAsync(CancellationToken cancellationToken);
    }
    public class FacultyService : IFacultyService
    {
        private readonly UniversityDbContext _dbContext;
        public FacultyService(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Faculty?> DeleteFaculty(long id, CancellationToken cancellationToken = default)
        {
            Faculty faculty = await _dbContext.Faculties.FindAsync(id);
            if (faculty is null) throw new Exception("Не найдена кафедра");
            _dbContext.Remove(faculty);
            await _dbContext.SaveChangesAsync();
            return faculty;
        }

        public async Task<Faculty> CreateFaculty(FacultyDTO facultyDTO, CancellationToken cancellationToken = default)
        {
            Faculty faculty = new Faculty() { Name = facultyDTO.Name};
            await _dbContext.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();
            return faculty;
        }

        public Task<Faculty[]> IndexFacultyAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Faculties.ToArrayAsync();
        }
    }
}
