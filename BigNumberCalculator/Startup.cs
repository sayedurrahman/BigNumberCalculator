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
            services.AddScoped<BigNumberCalculatorService.IArithmeticService, BigNumberCalculatorService.ArithmeticService>();
            services.AddScoped<BigNumberCalculatorService.IBigNumberService, BigNumberCalculatorService.BigNumberService>();

            // Setup connection string and configure for all pc/host
            string connectionString = Configuration.GetConnectionString("DefaultConnection").Replace("%CONTENTROOTPATH%", _contentRootPath);
            services.AddDbContext<BigNumberCalculatorRepository.BigDataContext>(options => options.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BigNumberCalculatorRepository.BigDataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            app.UseMvc();
        }
    }
}
