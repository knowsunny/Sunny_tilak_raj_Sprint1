using ProjectManagement.Entities;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class ProjectService : IProjectService
    {
        public Task<bool> Create(Project project)
        {
            throw new NotImplementedException();
        }

        public Project Get(int projectId)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<Project> GetProjectByProjectId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
