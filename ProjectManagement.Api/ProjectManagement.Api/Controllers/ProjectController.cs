﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<string> Get(int id)
        {
            if (id > 0)
            {
                var project = _projectService.GetProjectByProjectId(id);
                return Ok(project);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            var isProjectCreationSuccessful = await _projectService.Create(project);

            return Ok(isProjectCreationSuccessful);
        }

        [HttpPut]
        public async  Task<IActionResult> UpdateProject([FromBody] Project project)
        {
            var isProjectUpdationSuccessful = await _projectService.Update(project);

            return Ok(isProjectUpdationSuccessful);
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }
    }
}