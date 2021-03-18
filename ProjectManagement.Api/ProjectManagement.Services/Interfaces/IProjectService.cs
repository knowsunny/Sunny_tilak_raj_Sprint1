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
        Project Create(Project project);

        bool Update(Project project);

        List<Project> GetAllProjects();

        Project GetProjectByProjectId(long Id);
        bool Delete(long id);
    }
}
