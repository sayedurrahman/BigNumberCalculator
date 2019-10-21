using BigNumberCalculator.Core;
using BigNumberCalculator.Core.ArithmeticOparationService;
using BigNumberCalculator.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BigNumberCalculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _contentRootPath = env.ContentRootPath;
        }

        private string _contentRootPath = "";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IArithmeticService, ArithmeticService>();
            services.AddScoped<ICoreService, CoreService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<UserCalculatorRepository, UserCalculatorRepository>();
            

            // Setup connection string and configure for all pc/host
            string connectionString = Configuration.GetConnectionString("DefaultConnection").Replace("%CONTENTROOTPATH%", _contentRootPath);
            services.AddDbContext<BigDataContext>(options => options.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BigDataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.Database.EnsureCreated();

            app.UseMvc();
        }
    }
}
