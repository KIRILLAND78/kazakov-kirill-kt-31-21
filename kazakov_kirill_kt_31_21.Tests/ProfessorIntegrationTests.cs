using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.Filters.ProfessorFilters;
using kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_kirill_kt_31_21.Tests
{
    public class ProfessorIntegrationTests
    {
        public readonly DbContextOptions<UniversityDbContext> _dbContextOptions;
        public ProfessorIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<UniversityDbContext>()
                .UseInMemoryDatabase(databaseName: "uni_db")
                .Options;
        }
        
        public async Task FillDb(UniversityDbContext ctx)
        {
            ctx.Professors.RemoveRange(ctx.Professors);
            ctx.Ranks.RemoveRange(ctx.Ranks);
            ctx.Posts.RemoveRange(ctx.Posts);
            ctx.Faculties.RemoveRange(ctx.Faculties);
            await ctx.SaveChangesAsync();
            var groups = new List<Faculty>
            {
                new Faculty(){Name = "ИВТ"},
                new Faculty(){Name = "Медицинский"},
                new Faculty(){Name = "ФизМат"},
            };
            await ctx.Faculties.AddRangeAsync(groups);
            var ranks = new List<Rank>
            {
                new Rank() {Name = "Ученая степень 1"},
                new Rank() {Name = "Ученая степень 2"},
            };
            await ctx.Ranks.AddRangeAsync(ranks);
            var posts = new List<Post>
            {
                new Post() {Name = "Должность 1"},
                new Post() {Name = "Должность 2"},
            };
            var professors = new List<Professor>
            {
                new Professor() {Name = "Иванов Иван Иванович 1 1 1", FacultyId = 1, RankId = 1, PostId =  1},
                new Professor() {Name = "Иванов Иван Иванович 1 2 1", FacultyId = 1, RankId = 2, PostId =  1},
                new Professor() {Name = "Иванов Иван Иванович 1 1 2", FacultyId = 1, RankId = 1, PostId =  2},
                new Professor() {Name = "Иванов Иван Иванович 1 2 2", FacultyId = 1, RankId = 2, PostId =  2},
                new Professor() {Name = "Иванов Иван Иванович 2 1 1", FacultyId = 2, RankId = 1, PostId =  1},
                new Professor() {Name = "Иванов Иван Иванович 3 1 1", FacultyId = 3, RankId = 1, PostId =  1},
            };
            await ctx.Ranks.AddRangeAsync(ranks);
            await ctx.Faculties.AddRangeAsync(groups);
            await ctx.Posts.AddRangeAsync(posts);
            await ctx.Professors.AddRangeAsync(professors);

            await ctx.SaveChangesAsync();
        }

        [Fact]
        public async Task GetProfessorsByFilterAsync_EmptyFilter_SixObjects()
        {
            // Arrange
            var ctx = new UniversityDbContext(_dbContextOptions);
            var professorService = new ProfessorService(ctx);
            await FillDb(ctx);
            var filter = new ProfessorGroupFilter
            {

            };
            var result = await professorService.GetProfessorsByFilterAsync(filter, CancellationToken.None);

            Assert.Equal(6, result.Count);
        }

        [Fact]
        public async Task GetProfessorsByFilterAsync_AllFilter_OneObjects()
        {
            // Arrange
            var ctx = new UniversityDbContext(_dbContextOptions);
            var professorService = new ProfessorService(ctx);
            await FillDb(ctx);

            var filter = new ProfessorGroupFilter
            {
                FacultyId = 1,
                PostId = 1,
                RankId = 1
            };
            var result = await professorService.GetProfessorsByFilterAsync(filter, CancellationToken.None);
            Assert.Equal(1, result.Count);
        }
    }
}
