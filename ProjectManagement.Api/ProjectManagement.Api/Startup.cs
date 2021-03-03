using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Shared;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Api
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
            services.AddDbContext<PMContext>(opt => opt.UseInMemoryDatabase("projectManagementApp"));
            services.AddControllers();

            ConfigureTransientServices(services);

        }

        private void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITaskService, TaskService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var context = serviceProvider.GetService<PMContext>();
            AddTestData(context);
        }
        private static void AddTestData(PMContext context)
        {
            var testUser1 = new Entities.User
            {
                Email = "abc123",
                FirstName = "Luke",
                LastName = "Skywalker"
            };

            context.Users.Add(testUser1);

            context.SaveChanges();
        }
    }
}
