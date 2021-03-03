using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Interfaces
{
    public interface ITaskService
    {
        Task<bool> Create(ProjectManagement.Entities.Task task);

        Task<bool> Update(ProjectManagement.Entities.Task task);
        Task Get(int taskId);

        IOrderedQueryable<ProjectManagement.Entities.Task> GetAllTasks();

        IOrderedQueryable<ProjectManagement.Entities.Task> GetTaskByTaskId(int Id); 

    }
}
