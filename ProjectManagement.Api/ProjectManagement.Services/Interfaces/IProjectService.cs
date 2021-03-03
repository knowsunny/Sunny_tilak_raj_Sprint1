using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<bool> Create(Project project);

        Task<bool> Update(Project project);
        Project Get(int projectId);

        IOrderedQueryable<Project> GetAllProjects();

        IOrderedQueryable<Project> GetProjectByProjectId(int Id);

    }
}
