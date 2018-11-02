using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliaçãoG1.Interfaces;
using AvaliaçãoG1.Models;
using AvaliaçãoG1.Repositórios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AvaliaçãoG1
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
            services.AddMvc();

            services.AddDbContext<DataContext>(x =>
                    x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IPlanoDeSaudeRepository, PlanoDeSaudeRepository>();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
