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
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Entities;

namespace ProjectManagement.Api
{
    public class Startup
    {
        private const string V = "Mar 18 2021";

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
            services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBaseRepository<Task>, BaseRepository<Task>>();
            services.AddTransient<IBaseRepository<Project>, BaseRepository<Project>>();

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
            User testUser1 = new User
            {
                Id=1,
                Email = "sunny@xyz.com",
                FirstName = "Sunny",
                LastName = "Kumar",
                Password="changeit"
            };

            User testUser2 = new User
            {
                Id = 2,
                Email = "harsh@xyz.com",
                FirstName = "Harsh",
                LastName = "Verma",
                Password = "forgetit"
            };

            Task testTask1 = new Task
            {
                Id = 3,
                ProjectID = 1,
                Detail = "this is a task 1 for management project1",
                CreatedOn = DateTime.Parse(V),
                Status = Entities.Enums.TaskStatus.New,
                AssignedToUserID = 1
            };

            Project testproject1 = new Project
            {
                Id = 4,
                Name = "ProjectManagement",
                Detail = "this is a project management project",
                CreatedOn = DateTime.Parse(V)
            };

            Project testproject2 = new Project
            {
                Id = 5,
                Name = "ProjectManagement2",
                Detail = "this is a project management project2",
                CreatedOn = DateTime.Parse(V)
            };

            

            Task testTask2 = new Task
            {
                Id = 6,
                ProjectID = 4,
                Detail = "this is a task 2 for management project1",
                CreatedOn = DateTime.Parse(V),
                Status = Entities.Enums.TaskStatus.InProgress,
                AssignedToUserID = 2
            };

            Task testTask3 = new Task
            {
                Id = 7,
                ProjectID = 5,
                Detail = "this is a task 1 for management project2",
                CreatedOn = DateTime.Parse(V),
                Status = Entities.Enums.TaskStatus.Completed,
                AssignedToUserID = 1
            };


            context.Users.Add(testUser1);
            context.Users.Add(testUser2);
            context.SaveChanges();

            context.Tasks.Add(testTask1);
            context.Tasks.Add(testTask2);
            context.Tasks.Add(testTask3);
            context.SaveChanges();
            context.Projects.Add(testproject1);
            context.Projects.Add(testproject2);

            context.SaveChanges();
        }
    }
}
