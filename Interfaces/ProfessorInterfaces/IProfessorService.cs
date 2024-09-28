using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces
{
    public interface IProfessorService
    {
        public Task<List<Professor>> GetProfessorsByFilterAsync(ProfessorGroupFilter filter, CancellationToken cancellationToken);
    }
    public class ProfessorService : IProfessorService
    {
        private readonly UniversityDbContext _dbContext;
        public ProfessorService(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Professor>> GetProfessorsByFilterAsync(ProfessorGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var professors = _dbContext.Professors.AsQueryable();
            if (filter.FacultyId != null) professors = professors.Where(x=>x.FacultyId==filter.FacultyId);
            if (filter.PostId != null) professors = professors.Where(x => x.PostId == filter.PostId);
            if (filter.RankId != null) professors = professors.Where(x => x.RankId == filter.RankId);
            return professors.ToListAsync();
        }
    }
}
