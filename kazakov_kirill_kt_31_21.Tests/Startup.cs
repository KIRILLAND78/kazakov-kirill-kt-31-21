using kazakov_kirill_kt_31_21.Data;
using kazakov_kirill_kt_31_21.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace kazakov_kirill_kt_31_21.Tests
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();

            services.AddDbContext<UniversityDbContext>(settings=>settings.UseInMemoryDatabase(databaseName: "uni_db"));
        }
    }
}