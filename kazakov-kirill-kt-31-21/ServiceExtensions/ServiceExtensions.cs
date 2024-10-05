using kazakov_kirill_kt_31_21.Interfaces.FacultyInterfaces;
using kazakov_kirill_kt_31_21.Interfaces.ProfessorInterfaces;

namespace kazakov_kirill_kt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IProfessorService, ProfessorService>();

            return services;
        }
    }
}
