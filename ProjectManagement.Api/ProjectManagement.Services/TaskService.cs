using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class TaskService : ITaskService
    {
        public Task<bool> Create(ProjectManagement.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task Get(int taskId)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<ProjectManagement.Entities.Task> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<ProjectManagement.Entities.Task> GetTaskByTaskId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProjectManagement.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
