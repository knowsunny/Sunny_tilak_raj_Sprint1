using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class TaskService : ITaskService
    {

        private readonly IBaseRepository<Task> _repository;

        public TaskService(IBaseRepository<Task> repository)
        {
            _repository = repository;
        }
        public Task Create(ProjectManagement.Entities.Task task)
        {
            var result = _repository.Add(task);
            return (Task)result;
        }

        public List<Task> GetAllTasks()
        {
            var result = _repository.Get();
            return result.Cast<Task>().ToList();
        }

        public Task GetTaskByTaskId(int Id)
        {
            var result = _repository.Get(Id);
            return (Task)result;
        }

        public bool Update(ProjectManagement.Entities.Task task)
        {
            var ret = true;
            var result = _repository.Update(task);
            return ret;
        }
        public bool Delete(long Id)
        {
            var result = _repository.Delete(Id);
            return result;
        }
    }
}
