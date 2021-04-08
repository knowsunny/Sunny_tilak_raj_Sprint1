using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Project")]
    public class ProjectController : BaseController<Project>
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            if (id > 0)
            {
                var project = _projectService.GetProjectByProjectId(id);
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            var isProjectCreationSuccessful = _projectService.Create(project);

            return Ok(isProjectCreationSuccessful);
        }

        [HttpPut]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            var isProjectUpdationSuccessful =  _projectService.Update(project);

            return Ok(isProjectUpdationSuccessful);
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(long id)
        {
            var isProjectDeleted = _projectService.Delete(id);
            return Ok(isProjectDeleted);
        }
    }
}
