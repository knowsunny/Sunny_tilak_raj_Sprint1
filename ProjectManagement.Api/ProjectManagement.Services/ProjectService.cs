using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository<Project> _repository;

        public ProjectService(IBaseRepository<Project> repository)
        {
            _repository = repository;
        }

        public Project Create(Project project)
        {
            var result = _repository.Add(project);
            return (Project)result;
        }

        public List<Project> GetAllProjects()
        {
            var result = _repository.Get();
            return result.Cast<Project>().ToList();
        }

        public Project GetProjectByProjectId(long Id)
        {
            var result = _repository.Get(Id);
            return (Project)result;
        }

        public bool Update(Project project)
        {
            var ret = true;
            var result = _repository.Update(project);
            return ret;
        }
        public bool Delete(long Id)
        {
            var result = _repository.Delete(Id);
            return result;
        }
    }
}
