using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : BaseController<ProjectManagement.Entities.Task>
    {
        ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id > 0)
            {
                var task = _taskService.GetTaskByTaskId(id);
                return Ok(task);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] ProjectManagement.Entities.Task task)
        {
            var isTaskCreationSuccessful = await _taskService.Create(task);

            return Ok(isTaskCreationSuccessful);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody]  ProjectManagement.Entities.Task task)
        {
            var isTaskUpdationSuccessful = await _taskService.Update(task);

            return Ok(isTaskUpdationSuccessful);
        }

        [HttpGet]
        public IActionResult GetAllTask()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }
    }
}
