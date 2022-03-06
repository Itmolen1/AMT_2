using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Interfaces;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddScoped<IUserRepository, MockUserRepository>();
            services.AddScoped<IBloodGroupRepository, MockBloodGroupRepository>();
            services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IDepartmentRepository, MockDepartmentRepository>();
            services.AddScoped<IDesignationRepository, MockDesignationRepository>();
            services.AddScoped<ITrackUpdateRepository, MockTrackUpdateRepository>();
            services.AddScoped<IUnitRepository, MockUnitRepository>();
            services.AddScoped<IProductRepository, MockProductRepository>();
            services.AddScoped<ICustomerRepository, MockCustomerRepository>();
            services.AddScoped<IVenderRepository, MockVenderRepository>();
            services.AddScoped<IVehicleTypeRepository, MockVehicleTypeRepository>();
            services.AddScoped<IVehicleRepository, MockVehicleRepository>();
            services.AddScoped<IHomeRepository, MockHomeRepository>();
            services.AddScoped<IControlAccountRepository, MockControlAccountRepository>();
            services.AddScoped<IHeadAccountRepository, MockHeadAccountRepository>();
            services.AddScoped<IAccountRepository, MockAccountRepository>();
            services.AddScoped<ITransictionRepository, MockTransictionInformations>();
            services.AddScoped<IQuotationRepository, MockQuotationRepository>();
            services.AddScoped<IExpenseRepository, MockExpenseRepository>();
           
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
