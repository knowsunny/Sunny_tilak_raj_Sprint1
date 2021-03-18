using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Services.Interfaces
{
    public interface ITaskService
    {
        Task Create(ProjectManagement.Entities.Task task);

        bool Update(ProjectManagement.Entities.Task task);

        List<Task> GetAllTasks();

        Task GetTaskByTaskId(int Id);

        bool Delete(long id);
    }
}
